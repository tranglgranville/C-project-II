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
    public partial class TypeReport : Form
    {
        public TypeReport()
        {
            InitializeComponent();
            fillDataTable();

        }
        private void fillDataTable ()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();
                string sql = "SELECT appointmentId AS 'APPOINTMENT ID', type AS 'TYPE', start AS 'START DATE' FROM appointment";
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewType.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["START DATE"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["START DATE"], TimeZoneInfo.Local).ToString();
                }
                dataGridViewType.Columns[2].DefaultCellStyle.Format = "dd-MM-yyyy";

                result.Text = "Report: Number of appointment types by month \r\n\r\n";
                string[] Months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                foreach(string month in Months)
                {
                    result.Text = result.Text + month + "\r\n";
                    int presentation = 0;
                    int scrum = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (month == Months[((DateTime)row["START DATE"]).Month - 1])
                        {
                            if(row["type"].ToString() == "Presentation")
                            {
                                presentation++;
                            }
                            if(row["type"].ToString() == "Scrum")
                            {
                                scrum++;
                            }
                        }
                    }
                    result.Text = result.Text +
                        "\tPresentation\t" + presentation + "\r\n" +
                        "\tScrum\t\t" + scrum + "\r\n";
                    result.Select(0, 0);
                }
                
            }
        }
       
        private void Cancel_Click(object sender, EventArgs e)
        {
            var appointmentRecord = new AppointmentRecord();
            appointmentRecord.Show();
            Hide();
        }
    }
}
