using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class Room : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=HotelReservationDB;" +
              "Username=postgres; password=12345");
        public Room()
        {
            InitializeComponent();
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM public.\"Rooms\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Sort(dataGridView1.Columns["RoomID"], ListSortDirection.Ascending);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

                // Veri tiplerine uygunluk kontrolü
                if (int.TryParse(textRoomID.Text, out int RoomID) &&
                    int.TryParse(textCapacity.Text, out int Capacity) &&
                    !string.IsNullOrEmpty(textRoomType.Text) &&
                    int.TryParse(textPrice.Text, out int Price) &&
                    bool.TryParse(textSituation.Text, out bool Situation))
                {
                    // Situation değeri "True" veya "False" olarak girilirse, küçük harfe çevir
                    textSituation.Text = textSituation.Text.ToLower();

                    // Situation değerini bool'a çevir
                    if (textSituation.Text == "true")
                    {
                        Situation = true;
                    }
                    else if (textSituation.Text == "false")
                    {
                        Situation = false;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir Situation (bool) girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                        return;
                    }

                    // RoomID'nin veritabanında mevcut olup olmadığını kontrol et
                    if (IsRoomIDUnique(RoomID))
                    {
                        NpgsqlCommand roomAddCommand = new NpgsqlCommand("INSERT INTO public.\"Rooms\" (\"RoomID\", \"Capacity\", \"RoomType\", \"Price\", \"Situation\") VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti);
                        roomAddCommand.Parameters.AddWithValue("@p1", RoomID);
                        roomAddCommand.Parameters.AddWithValue("@p2", Capacity);
                        roomAddCommand.Parameters.AddWithValue("@p3", textRoomType.Text);
                        roomAddCommand.Parameters.AddWithValue("@p4", Price);
                        roomAddCommand.Parameters.AddWithValue("@p5", Situation);

                        roomAddCommand.ExecuteNonQuery();

                        MessageBox.Show("Oda ekleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        baglanti.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu RoomID zaten mevcut. Lütfen benzersiz bir RoomID girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir RoomID (int), Capacity (int), RoomType (string), Price (int) ve Situation (bool) girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }


        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

                // Transaction başlat
                using (var transaction = baglanti.BeginTransaction())
                {
                    try
                    {
                        int roomIDToDelete = int.Parse(textRoomID.Text);

                        // Veritabanında belirtilen RoomID'ye sahip bir oda var mı kontrol et
                        if (IsRoomExist(roomIDToDelete))
                        {
                            // Reservations tablosundan kaydı sil
                            NpgsqlCommand deleteReservationsCommand = new NpgsqlCommand("DELETE FROM public.\"Rooms\" WHERE \"RoomID\"=@p1", baglanti);
                            deleteReservationsCommand.Parameters.AddWithValue("@p1", roomIDToDelete);
                            deleteReservationsCommand.ExecuteNonQuery();

                            // Commit yaparak işlemleri kaydet
                            transaction.Commit();

                            MessageBox.Show("Oda silme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen RoomID ile oda bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda geri al
                        transaction.Rollback();
                        MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                baglanti.Close();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            //// Kullanıcıdan gelen değerleri integer'a dönüştür
            //if (int.TryParse(textRoomID.Text, out int RoomID))
            //{
            //    // Bağlantıyı aç
            //    baglanti.Open();

            //    // SQL sorgusu oluştur
            //    string sorgu = "SELECT * FROM public.\"Rooms\" WHERE \"RoomID\" = @p1";

            //    // Komutu ve bağlantıyı oluştur
            //    NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            //    komut.Parameters.AddWithValue("@p1", RoomID);

            //    // DataAdapter ve DataTable oluştur
            //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
            //    DataTable dt = new DataTable();

            //    // Verileri DataTable'a doldur
            //    da.Fill(dt);

            //    // DataGridView'e verileri ata
            //    dataGridView1.DataSource = dt;

            //}

            //else
            //{
            //    MessageBox.Show("Geçerli bir RoomID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //// Bağlantıyı kapat
            //baglanti.Close();

            // Kullanıcıdan gelen değerleri integer'a dönüştür
            if (int.TryParse(textRoomID.Text, out int RoomID))
            {
                // Bağlantıyı aç
                baglanti.Open();

                // SQL sorgusu oluştur
                string sorgu = "SELECT * FROM public.\"Rooms\" WHERE \"RoomID\" = @p1";

                // Komutu ve bağlantıyı oluştur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", RoomID);

                // DataAdapter ve DataTable oluştur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // Eğer oda bulunamadıysa
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Belirtilen RoomID ile oda bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Oda bulunduysa, DataGridView'e verileri ata
                    dataGridView1.DataSource = dt;
                }

                // Bağlantıyı kapat
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Geçerli bir RoomID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            if (int.TryParse(textRoomID.Text, out int RoomID) &&
                    int.TryParse(textCapacity.Text, out int Capacity) &&
                    !string.IsNullOrEmpty(textRoomType.Text) &&
                    int.TryParse(textPrice.Text, out int Price) &&
                    bool.TryParse(textSituation.Text, out bool Situation))
            {
                NpgsqlCommand updateCommand = new NpgsqlCommand("UPDATE public.\"Rooms\" SET \"Capacity\" = @p2, \"RoomType\" = @p3, \"Price\" = @p4, \"Situation\" = @p5 WHERE \"RoomID\" = @p1", baglanti);
                updateCommand.Parameters.AddWithValue("@p1", RoomID);
                updateCommand.Parameters.AddWithValue("@p2", Capacity);
                updateCommand.Parameters.AddWithValue("@p3", textRoomType.Text);
                updateCommand.Parameters.AddWithValue("@p4", Price);
                updateCommand.Parameters.AddWithValue("@p5", Situation);

                int affectedRows = updateCommand.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Oda güncelleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen RoomID ile oda bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir RoomID, Capacity, Room Type , Price ve Situation giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Satır seçildiyse
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // İlgili hücrelerin değerlerini al
                int roomID;
                if (int.TryParse(row.Cells["RoomID"].Value.ToString(), out roomID))
                {
                    textRoomID.Text = roomID.ToString();
                }

                int capacity;
                if (int.TryParse(row.Cells["Capacity"].Value.ToString(), out capacity))
                {
                    textCapacity.Text = capacity.ToString();
                }

                textRoomType.Text = row.Cells["RoomType"].Value.ToString();

                int price;
                if (int.TryParse(row.Cells["Price"].Value.ToString(), out price))
                {
                    textPrice.Text = price.ToString();
                }

                bool situation;
                if (bool.TryParse(row.Cells["Situation"].Value.ToString(), out situation))
                {
                    textSituation.Text = situation.ToString();
                }
            }
        }
        private bool IsRoomIDUnique(int roomID)
        {
            // Veritabanında RoomID'nin benzersiz olup olmadığını kontrol et
            NpgsqlCommand checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Rooms\" WHERE \"RoomID\" = @p1", baglanti);
            checkCommand.Parameters.AddWithValue("@p1", roomID);

            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            return count == 0;
        }

        private bool IsRoomExist(int roomID)
        {
            // Veritabanında belirtilen RoomID'ye sahip bir oda var mı kontrol et
            NpgsqlCommand checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Rooms\" WHERE \"RoomID\" = @p1", baglanti);
            checkCommand.Parameters.AddWithValue("@p1", roomID);

            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            return count > 0;
        }
    }
}
