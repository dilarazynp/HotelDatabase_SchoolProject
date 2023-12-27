using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelReservation
{
    public partial class Customer : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=HotelReservationDB;" +
              "Username=postgres; password=12345");
        public Customer()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM public.\"Customers\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Sort(dataGridView1.Columns["CustomerID"], ListSortDirection.Ascending);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Bağlantı kapalıysa aç
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    baglanti.Open();

                    if (int.TryParse(textCustomerID.Text, out int customerID) &&
                        !string.IsNullOrEmpty(textName.Text) &&
                        !string.IsNullOrEmpty(textLastName.Text) &&
                        !string.IsNullOrEmpty(textEmail.Text) &&
                        int.TryParse(textPhoneNumber.Text, out int phoneNumber) &&
                        !string.IsNullOrEmpty(textAddress.Text))
                    {
                        // CustomerID var mı kontrolü
                        NpgsqlCommand checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Customers\" WHERE \"CustomerID\" = @p1", baglanti);
                        checkCommand.Parameters.AddWithValue("@p1", customerID);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Bu CustomerID zaten kullanılıyor. Lütfen başka bir CustomerID seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Metodu burada sonlandırın, işleme devam etmeyin
                        }

                        // Müşteri ekleme sorgusu
                        NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO public.\"Customers\" (\"CustomerID\", \"Name\", \"LastName\", \"Email\", \"PhoneNumber\" , \"Address\") VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
                        komut1.Parameters.AddWithValue("@p1", customerID);
                        komut1.Parameters.AddWithValue("@p2", textName.Text);
                        komut1.Parameters.AddWithValue("@p3", textLastName.Text);
                        komut1.Parameters.AddWithValue("@p4", textEmail.Text);
                        komut1.Parameters.AddWithValue("@p5", phoneNumber);
                        komut1.Parameters.AddWithValue("@p6", textAddress.Text);

                        int affectedRows = komut1.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Müşteri ekleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Müşteri eklenirken bir sorun oluştu. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir CustomerID, Name, Last Name, Email, Phone Number ve Address girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müşteri eklerken bir hata oluştu. Lütfen girdiğiniz bilgileri kontrol edin ve tekrar deneyin.\n\nHata Detayı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglanti.Close();
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            // Transaction başlat
            using (var transaction = baglanti.BeginTransaction())
            {
                try
                {
                    int customerIDToDelete;

                    if (int.TryParse(textCustomerID.Text, out customerIDToDelete))
                    {
                        // Müşteri var mı kontrolü
                        NpgsqlCommand checkCustomerCommand = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Customers\" WHERE \"CustomerID\"=@p1", baglanti);
                        checkCustomerCommand.Parameters.AddWithValue("@p1", customerIDToDelete);

                        int customerCount = Convert.ToInt32(checkCustomerCommand.ExecuteScalar());

                        if (customerCount == 0)
                        {
                            MessageBox.Show("Bu müşteri zaten silinmiş veya bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return; // Metodu burada sonlandırın, işleme devam etmeyin
                        }

                        // Müşteri silme sorgusu
                        NpgsqlCommand deleteCustomerCommand = new NpgsqlCommand("DELETE FROM public.\"Customers\" WHERE \"CustomerID\"=@p1", baglanti);
                        deleteCustomerCommand.Parameters.AddWithValue("@p1", customerIDToDelete);
                        deleteCustomerCommand.ExecuteNonQuery();

                        // Commit yaparak işlemleri kaydet
                        transaction.Commit();

                        MessageBox.Show("Müşteri silme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir CustomerID girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda geri al
                    transaction.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglanti.Close();
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            if (int.TryParse(textCustomerID.Text, out int customerID) &&
                !string.IsNullOrEmpty(textName.Text) &&
                !string.IsNullOrEmpty(textLastName.Text) &&
                !string.IsNullOrEmpty(textEmail.Text) &&
                int.TryParse(textPhoneNumber.Text, out int phoneNumber) &&
                !string.IsNullOrEmpty(textAddress.Text))
            {
                try
                {
                    // Müşteriyi bul ve güncelle
                    NpgsqlCommand findCustomerCommand = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Customers\" WHERE \"CustomerID\"=@p1", baglanti);
                    findCustomerCommand.Parameters.AddWithValue("@p1", customerID);

                    int customerCount = Convert.ToInt32(findCustomerCommand.ExecuteScalar());

                    if (customerCount > 0)
                    {
                        NpgsqlCommand updateCommand = new NpgsqlCommand("UPDATE public.\"Customers\" SET \"Name\" = @p2, \"LastName\" = @p3, \"Email\" = @p4, \"PhoneNumber\" = @p5, \"Address\" = @p6 WHERE \"CustomerID\" = @p1", baglanti);
                        updateCommand.Parameters.AddWithValue("@p1", customerID);
                        updateCommand.Parameters.AddWithValue("@p2", textName.Text);
                        updateCommand.Parameters.AddWithValue("@p3", textLastName.Text);
                        updateCommand.Parameters.AddWithValue("@p4", textEmail.Text);
                        updateCommand.Parameters.AddWithValue("@p5", phoneNumber);
                        updateCommand.Parameters.AddWithValue("@p6", textAddress.Text);

                        int affectedRows = updateCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Müşteri güncelleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Müşteri güncelleme işlemi başarısız oldu. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen CustomerID ile müşteri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir CustomerID, Name, Last Name, Email, Phone Number ve Address giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan gelen değerleri integer'a dönüştür
            if (int.TryParse(textCustomerID.Text, out int reservationID))
            {
                // Bağlantıyı aç
                baglanti.Open();

                // SQL sorgusu oluştur
                string sorgu = "SELECT * FROM public.\"Customers\" WHERE \"CustomerID\" = @p1";

                // Komutu ve bağlantıyı oluştur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", reservationID);

                // DataAdapter ve DataTable oluştur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'e verileri ata
                dataGridView1.DataSource = dt;

            }
            else if (int.TryParse(textName.Text, out int customerID))
            {
                // Bağlantıyı aç
                baglanti.Open();

                // SQL sorgusu oluştur
                string sorgu = "SELECT * FROM public.\"Customers\" WHERE \"Name\" = @p1";

                // Komutu ve bağlantıyı oluştur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", customerID);

                // DataAdapter ve DataTable oluştur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'e verileri ata
                dataGridView1.DataSource = dt;

            }
            else if (int.TryParse(textLastName.Text, out int roomID))
            {
                // Bağlantıyı aç
                baglanti.Open();

                // SQL sorgusu oluştur
                string sorgu = "SELECT * FROM public.\"Customers\" WHERE \"LastName\" = @p1";

                // Komutu ve bağlantıyı oluştur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", roomID);

                // DataAdapter ve DataTable oluştur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'e verileri ata
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Geçerli bir ReservationID, CustomerID veya RoomID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Bağlantıyı kapat
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Satır seçildiyse
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // İlgili hücrelerin değerlerini al
                int CustomerID;
                if (int.TryParse(row.Cells["CustomerID"].Value.ToString(), out CustomerID))
                {
                    textCustomerID.Text = CustomerID.ToString();
                }

                textName.Text = row.Cells["Name"].Value.ToString();
                textLastName.Text = row.Cells["LastName"].Value.ToString();
                textEmail.Text = row.Cells["Email"].Value.ToString();
                textAddress.Text = row.Cells["Address"].Value.ToString();

                int PhoneNumber;
                if (int.TryParse(row.Cells["PhoneNumber"].Value.ToString(), out PhoneNumber))
                {
                    textPhoneNumber.Text = PhoneNumber.ToString();
                }

            }
        }
    }

}

