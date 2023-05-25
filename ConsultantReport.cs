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
    public partial class ConsultantReport : Form
    {
        public int comboValue;
        public string sqlTable = "SELECT appointment.userId, user.userName, customerId, start AS 'START DATE', end AS 'END DATE' FROM user, appointment " +
            "WHERE user.userId = appointment.userId";
        public ConsultantReport()
        {
            InitializeComponent();
            GetUserID(sqlTable);
            dataGridViewUser.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewUser.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            comboBox();
        }
        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboUser.SelectedItem != null)
            {
                comboValue = int.Parse(comboUser.SelectedItem.ToString());
            }
            string sqlUser = $"SELECT userId AS 'USER ID', customerId AS 'CUSTOMER ID', start AS 'START DATE', end AS 'END DATE' FROM appointment WHERE userId = '{comboValue}'";
            GetUserID(sqlUser);
        }
        private void comboBox()
        {
            using(MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();
                string sql = "SELECT userId from user";
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    comboUser.Items.Add(int.Parse(read["userId"].ToString()));
                    comboUser.DisplayMember = (read["userId"].ToString());
                    comboUser.ValueMember = (read["userId"].ToString());
                }
                con.Close();
            }
        }
        private void GetUserID(string sql)
        {
            using(MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();                
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewUser.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["START DATE"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["START DATE"], TimeZoneInfo.Local).ToString();
                    dt.Rows[i]["END DATE"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["END DATE"], TimeZoneInfo.Local).ToString();
                }
                con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var main = new Main();
            main.Show();
            Hide();
        }

       
    }
}
