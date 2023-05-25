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
    public partial class CustomerReport : Form
    {        
        public string sqlFill = "SELECT customerId AS 'CUSTOMER ID', customerName AS 'CUSTOMER NAME', createdBy AS 'CREATED BY', createDate AS 'CREATE DATE' FROM customer";
        public CustomerReport()
        {
            InitializeComponent();
            fillTable(sqlFill);
            comboBox();
        }
        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string sqlSlect = $"SELECT customerId AS 'CUSTOMER ID', customerName AS 'CUSTOMER NAME', createdBy AS 'CREATED BY', createDate AS 'CREATE DATE' FROM customer WHERE createdBy = '"  + comboUser.SelectedItem + "'";

            fillTable(sqlSlect);
        }
        private void comboBox()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();
                string sql = "SELECT createdBy from user";
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    comboUser.Items.Add(read["createdBy"].ToString());
                    comboUser.DisplayMember = (read["createdBy"].ToString());
                    comboUser.ValueMember = (read["createdBy"].ToString());
                }
                con.Close();
            }
        }
        private void fillTable(string sql)
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewReport.DataSource = dt;
                con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["CREATE DATE"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["CREATE DATE"], TimeZoneInfo.Local).ToString();
                }
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            var record = new CustomerRecord();
            record.Show();
            Hide();
        }

        
    }
}
