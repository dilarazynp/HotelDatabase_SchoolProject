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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelReservation
{
    public partial class Reservation : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=HotelReservationDB;" +
              "Username=postgres; password=12345");
        public Reservation()
        {
            InitializeComponent();

        }
        private void btnList_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM public.\"Reservations\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Sort(dataGridView1.Columns["ReservationID"], ListSortDirection.Ascending);

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {// Baðlantý kapalýysa aç
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

                int price, customerID, roomID;
                DateTime checkInDate, checkOutDate;

                if (ValidateInput(out price, out customerID, out roomID, out checkInDate, out checkOutDate))
                {
                    // Kontrol iþlemleri
                    if (IsReservationValid(roomID, checkInDate, checkOutDate))
                    {
                        using (NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO public.\"Reservations\" (\"TotalPrice\", \"CustomerID\", \"RoomID\", \"CheckInDate\", \"CheckOutDate\") VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti))
                        {
                            komut1.Parameters.AddWithValue("@p1", price);
                            komut1.Parameters.AddWithValue("@p2", customerID);
                            komut1.Parameters.AddWithValue("@p3", roomID);
                            komut1.Parameters.AddWithValue("@p4", checkInDate);
                            komut1.Parameters.AddWithValue("@p5", checkOutDate);

                            komut1.ExecuteNonQuery();

                            MessageBox.Show("Rezervasyon ekleme iþlemi baþarýlý bir þekilde gerçekleþti.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu tarih aralýðýnda seçilen oda zaten rezerve edilmiþ.");
                    }
                }

                baglanti.Close();
            }


        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            // Transaction baþlat
            using (var transaction = baglanti.BeginTransaction())
            {
                try
                {
                    // Reservations tablosundan kaydý sil
                    NpgsqlCommand deleteReservationsCommand = new NpgsqlCommand("DELETE FROM public.\"Reservations\" WHERE \"ReservationID\"=@p1", baglanti);
                    deleteReservationsCommand.Parameters.AddWithValue("@p1", int.Parse(TxtReservationID.Text));
                    int affectedRowsReservations = deleteReservationsCommand.ExecuteNonQuery();

                    // Payment tablosundan ayný kaydý sil
                    NpgsqlCommand deletePaymentCommand = new NpgsqlCommand("DELETE FROM public.\"Payment\" WHERE \"ReservationID\"=@p1", baglanti);
                    deletePaymentCommand.Parameters.AddWithValue("@p1", int.Parse(TxtReservationID.Text));
                    int affectedRowsPayment = deletePaymentCommand.ExecuteNonQuery();

                    // Commit yaparak iþlemleri kaydet
                    transaction.Commit();

                    if (affectedRowsReservations == 0 && affectedRowsPayment == 0)
                    {
                        MessageBox.Show("Belirtilen ReservationID'ye sahip kayýt zaten silinmiþ.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ürün silme iþlemi baþarýlý bir þekilde gerçekleþti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda geri al
                    transaction.Rollback();
                    MessageBox.Show("Hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (int.TryParse(TxtReservationID.Text, out int reservationID) &&
                int.TryParse(textPrice.Text, out int price) &&
                int.TryParse(textCustomerID.Text, out int customerID) &&
                int.TryParse(textRoomID.Text, out int roomID))
            {
                // DateTimePicker'dan tarih deðerlerini al
                DateTime checkInDate = dateTimePickerCheckIn.Value;
                DateTime checkOutDate = dateTimePickerCheckOut.Value;

                NpgsqlCommand updateCommand = new NpgsqlCommand("UPDATE public.\"Reservations\" SET \"TotalPrice\"=@p1, \"CustomerID\"=@p2, \"RoomID\"=@p3, \"CheckInDate\"=@p4, \"CheckOutDate\"=@p5 WHERE \"ReservationID\"=@p6", baglanti);
                updateCommand.Parameters.AddWithValue("@p1", price);
                updateCommand.Parameters.AddWithValue("@p2", customerID);
                updateCommand.Parameters.AddWithValue("@p3", roomID);
                updateCommand.Parameters.AddWithValue("@p4", checkInDate);
                updateCommand.Parameters.AddWithValue("@p5", checkOutDate);
                updateCommand.Parameters.AddWithValue("@p6", reservationID);

                int affectedRows = updateCommand.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Rezervasyon güncelleme iþlemi baþarýlý bir þekilde gerçekleþti.");
                }
                else
                {
                    MessageBox.Show("Belirtilen ReservationID ile rezervasyon bulunamadý.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ReservationID, fiyat, müþteri kimliði, oda kimliði, giriþ tarihi ve çýkýþ tarihi girin.");
            }

            baglanti.Close();


        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kullanýcýdan gelen deðerleri integer'a dönüþtür
            if (int.TryParse(TxtReservationID.Text, out int reservationID))
            {
                // Baðlantýyý aç
                baglanti.Open();

                // SQL sorgusu oluþtur
                string sorgu = "SELECT * FROM public.\"Reservations\" WHERE \"ReservationID\" = @p1";

                // Komutu ve baðlantýyý oluþtur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", reservationID);

                // DataAdapter ve DataTable oluþtur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'e verileri ata
                dataGridView1.DataSource = dt;

            }
            else if (int.TryParse(textCustomerID.Text, out int customerID))
            {
                // Baðlantýyý aç
                baglanti.Open();

                // SQL sorgusu oluþtur
                string sorgu = "SELECT * FROM public.\"Reservations\" WHERE \"CustomerID\" = @p1";

                // Komutu ve baðlantýyý oluþtur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", customerID);

                // DataAdapter ve DataTable oluþtur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'e verileri ata
                dataGridView1.DataSource = dt;

            }
            else if (int.TryParse(textRoomID.Text, out int roomID))
            {
                // Baðlantýyý aç
                baglanti.Open();

                // SQL sorgusu oluþtur
                string sorgu = "SELECT * FROM public.\"Reservations\" WHERE \"RoomID\" = @p1";

                // Komutu ve baðlantýyý oluþtur
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", roomID);

                // DataAdapter ve DataTable oluþtur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                DataTable dt = new DataTable();

                // Verileri DataTable'a doldur
                da.Fill(dt);

                // DataGridView'e verileri ata
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Geçerli bir ReservationID, CustomerID veya RoomID giriniz!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Baðlantýyý kapat
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Satýr seçildiyse
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Ýlgili hücrelerin deðerlerini al
                int CustomerID;
                if (int.TryParse(row.Cells["CustomerID"].Value.ToString(), out CustomerID))
                {
                    textCustomerID.Text = CustomerID.ToString();
                }
                int roomID;
                if (int.TryParse(row.Cells["RoomID"].Value.ToString(), out roomID))
                {
                    textRoomID.Text = roomID.ToString();
                }

                int TotalPrice;
                if (int.TryParse(row.Cells["TotalPrice"].Value.ToString(), out TotalPrice))
                {
                    textPrice.Text = TotalPrice.ToString();
                }
                DateTime checkInDate;
                if (DateTime.TryParse(row.Cells["CheckInDate"].Value?.ToString(), out checkInDate))
                {
                    dateTimePickerCheckIn.Value = checkInDate;
                }
                else
                {
                    dateTimePickerCheckIn.Value = DateTime.Now; // Hata durumunda varsayýlan deðeri kullanma
                }

                DateTime checkOutDate;
                if (DateTime.TryParse(row.Cells["CheckOutDate"].Value?.ToString(), out checkOutDate))
                {
                    dateTimePickerCheckOut.Value = checkOutDate;
                }
                else
                {
                    dateTimePickerCheckOut.Value = DateTime.Now; // Hata durumunda varsayýlan deðeri kullanma
                }
            }

        }

        private bool IsReservationValid(int roomID, DateTime checkInDate, DateTime checkOutDate)
        {
            using (NpgsqlCommand checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Reservations\" WHERE \"RoomID\" = @roomID AND NOT (\"CheckOutDate\" <= @checkInDate OR \"CheckInDate\" >= @checkOutDate)", baglanti))
            {
                checkCommand.Parameters.AddWithValue("@roomID", roomID);
                checkCommand.Parameters.AddWithValue("@checkInDate", checkInDate);
                checkCommand.Parameters.AddWithValue("@checkOutDate", checkOutDate);

                int overlappingReservations = Convert.ToInt32(checkCommand.ExecuteScalar());

                return overlappingReservations == 0;
            }
        }


        private bool IsReservationExist(int reservationID)
        {
            // Veritabanýnda belirtilen ReservationID'ye sahip rezervasyon var mý kontrol et
            string query = "SELECT COUNT(*) FROM public.\"Reservations\" WHERE \"ReservationID\" = @ReservationID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, baglanti))
            {
                command.Parameters.AddWithValue("@ReservationID", reservationID);

                int count = Convert.ToInt32(command.ExecuteScalar());

                // Eðer rezervasyon sayýsý sýfýrsa, oda mevcut deðildir
                return count > 0;
            }
        }

        private bool ValidateInput(out int price, out int customerID, out int roomID, out DateTime checkInDate, out DateTime checkOutDate)
        {
            price = 0;
            customerID = 0;
            roomID = 0;
            checkInDate = DateTime.MinValue;
            checkOutDate = DateTime.MinValue;

            if (int.TryParse(textPrice.Text, out price) &&
                int.TryParse(textCustomerID.Text, out customerID) &&
                int.TryParse(textRoomID.Text, out roomID))
            {
                // DateTimePicker'dan tarih deðerlerini al
                checkInDate = dateTimePickerCheckIn.Value;
                checkOutDate = dateTimePickerCheckOut.Value;

                // Rezervasyonun çýkýþ tarihi, giriþ tarihinden büyük olmalýdýr
                if (checkOutDate > checkInDate)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Çýkýþ tarihi, giriþ tarihinden büyük olmalýdýr.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir fiyat, müþteri kimliði, oda kimliði, giriþ tarihi ve çýkýþ tarihi girin.");
            }

            return false;
        }

    }

}
