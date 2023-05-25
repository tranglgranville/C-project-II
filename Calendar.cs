using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Trang_Granville
{
    public partial class Calendar : Form
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
        DataTable dt = new DataTable(); 
        MySqlCommand cmd;
        DateTime currentDate;
        public Calendar()
        {
            InitializeComponent();

            currentDate = DateTime.Now;
            monthCalendar.AddBoldedDate(currentDate);           
        }

        private void handleAll()
        {
            string calendar = "SELECT appointmentId AS 'APPOINTMENT ID', appointment.customerId AS 'CUSTOMER ID', start AS 'START', end AS 'END' FROM appointment, customer WHERE appointment.customerId = customer.customerId ORDER BY appointmentId";
            DataGridViewFill(calendar);
            dataGridViewCalendar.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCalendar.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }
        private void handleWeek()
        {
            monthCalendar.RemoveAllBoldedDates();
            dt.Clear();
            int dow = (int)currentDate.DayOfWeek;
            string startDate = currentDate.AddDays(-dow).ToString("yyy-MM-dd"); //return the date of sunday, the first day of the week
            DateTime tempDate = Convert.ToDateTime(startDate);
            for(int i = 0; i < 7; i++)
            {
                monthCalendar.AddBoldedDate(tempDate.AddDays(i));
            }
            monthCalendar.UpdateBoldedDates();
            string endDate = currentDate.AddDays(7 - dow - 1).ToString("yyyy-MM-dd"); // return the date of Saturday, the last day of the week
            string sqlWeek = "SELECT appointmentId AS 'APPOINTMENT ID', customerId AS 'CUSTOMER ID', start AS 'START', end AS 'END' FROM appointment " +
                "WHERE start BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY appointmentId";
            DataGridViewFill(sqlWeek);          
        }

        private void handleMonth()
        {
            monthCalendar.RemoveAllBoldedDates();
            dt.Clear();
            int mo = currentDate.Month;
            int yr = currentDate.Year;
            int d = 0;
            string startDate = yr.ToString() + "-" + mo.ToString() + "-01" ;
            DateTime tempDate = Convert.ToDateTime(startDate);
            switch (mo)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    d = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    d = 30;
                    break;
                default:
                    d = 29;
                    break;
            }
            for (int i = 0; i < d; i++)
            {
                monthCalendar.AddBoldedDate(tempDate.AddDays(i));
            }
            monthCalendar.UpdateBoldedDates();
            //string endDate = yr.ToString() + "-" + mo.ToString() + "-" + d.ToString() + "-" + " 00:00:00 ";
            //DateTime end = Convert.ToDateTime(endDate);

            /*string sqlMonth = "SELECT appointmentId AS 'APPOINTMENT ID', customerId AS 'CUSTOMER ID' FROM appointment " +
                "WHERE start BETWEEN ('" + startDate + "') AND ('" + endDate + "')";*/
            
            string sqlMo = $"SELECT appointmentId AS 'APPOINTMENT ID', customerId AS 'CUSTOMER ID', start AS 'START', end AS 'END' FROM appointment WHERE MONTH(start) = '{mo}' ORDER BY appointmentId";
            DataGridViewFill(sqlMo);            
        }
       
        private void cancelButton_Click(object sender, EventArgs e)
        {
            var main = new Main();
            main.Show();
            Hide();
        }

        private void allAppointment_CheckedChanged(object sender, EventArgs e)
        {
            handleAll();
        }    

        private void byMonth_CheckedChanged(object sender, EventArgs e)
        {
            handleMonth();
        }

        private void byWeek_CheckedChanged(object sender, EventArgs e)
        {
            handleWeek();
        }
        
        private void DataGridViewFill(string str)
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();     
                cmd = new MySqlCommand(str, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewCalendar.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["start"], TimeZoneInfo.Local).ToString();
                    dt.Rows[i]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["end"], TimeZoneInfo.Local).ToString();
                }
                con.Close();
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDate = e.Start;
            if (byMonth.Checked)
            {
                handleMonth();
            }
            if (allAppointment.Checked)
            {
                handleAll();
            }
            else
                handleWeek();
        }
    }
}
