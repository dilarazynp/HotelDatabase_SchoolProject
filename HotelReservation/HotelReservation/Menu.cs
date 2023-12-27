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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.ShowDialog();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        private void Time_Click(object sender, EventArgs e)
        {
        }

        private void Date_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ShowDialog();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.ShowDialog();
        }
    }
}
