using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trang_Granville
{
    public partial class Main : Form
    {
        delegate string singOut(string username);
        public Main()
        {
            InitializeComponent();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {            
            var login = new LogIn();
            login.Show();
            Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            var customer = new CustomerRecord();
            customer.Show();
            Hide();
        }

        private void apptButton_Click(object sender, EventArgs e)
        {
            var appointment = new AppointmentRecord();
            appointment.Show();
            Hide();
        }

        private void calendar_Click(object sender, EventArgs e)
        {
            var calendar = new Calendar();
            calendar.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var consultant = new ConsultantReport();
            consultant.Show();
            Hide();
        }
    }
}
