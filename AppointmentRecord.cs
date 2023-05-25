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
using System.Globalization;
using System.IO;

namespace Trang_Granville
{
    public partial class AppointmentRecord : Form
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
        MySqlCommand cmd;
        public static int appoinmentID;
        
        public AppointmentRecord()
        {
            InitializeComponent();
            
            DataGridViewFill();
            dataGridViewAppt.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewAppt.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }
        int selectedRow;       

        private void dataGridViewAppt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAppt.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dataGridViewAppt.CurrentRow.DataBoundItem;
                appID.Text = (string)drv["Appointment ID"].ToString();
                appoinmentID = Int32.Parse(appID.Text);
                custID.Text = (string)drv["Customer ID"].ToString();
                customerName.Text = (string)drv["Customer Name"];
                typeApp.Text = (string)drv["Type"];
                startTime.Value = (DateTime)drv["Start Date"];
                endTime.Value = (DateTime)drv["End Date"];
            }            
        }
        
        private void addButton_Click(object sender, EventArgs e)
        {            
            try
            {                
                int customerIDText = int.Parse(custID.Text);
                string customerNameText = customerName.Text;
                string type = typeApp.Text;
                var start = TimeZoneInfo.ConvertTimeToUtc(startTime.Value);
                var end = TimeZoneInfo.ConvertTimeToUtc(endTime.Value);
                                
                if ( businessHour() == true && notOverlap() == true)
                {
                    con.Open();
                    string addAppointmentID = "INSERT INTO appointment VALUES(NULL, @CUSTOMERID, 1, 'not needed', 'not needed', 'not needed', 'not needed', " +
                        "@TYPE, 'not needed', @START, @END, NOW(), 'xx', NOW(), 'xx')";
                    cmd = new MySqlCommand(addAppointmentID, con);
                    cmd.Parameters.AddWithValue("@CUSTOMERID", customerIDText);
                    cmd.Parameters.AddWithValue("@TYPE", type);
                    cmd.Parameters.AddWithValue("@START", start);
                    cmd.Parameters.AddWithValue("@END", end);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    Clear();
                    DataGridViewFill();
                    con.Close();
                }
                /*else
                    MessageBox.Show("Please select a different time.");*/                
            }
            catch
            {
                MessageBox.Show("Unable to add the new appoinment. Please check all the entered values.");
            }            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {          
            try
            {
                int appointmentIDText = int.Parse(appID.Text);
                int customerIDText = int.Parse(custID.Text);
                string customerNameText = customerName.Text;
                string type = typeApp.Text;
                var start = TimeZoneInfo.ConvertTimeToUtc(startTime.Value);
                var end = TimeZoneInfo.ConvertTimeToUtc(endTime.Value); 

                selectedRow = dataGridViewAppt.SelectedCells[0].RowIndex;
                DataGridViewRow selected = dataGridViewAppt.Rows[selectedRow];
                int appointmentID = int.Parse(selected.Cells["Appointment ID"].Value.ToString());
                int customerID = int.Parse(selected.Cells["Customer ID"].Value.ToString());
                string name = selected.Cells["Customer Name"].Value.ToString();

                //error box for changing appointment ID or customer ID or customer name
                if (appointmentIDText != appointmentID || customerIDText != customerID || customerNameText != name)
                {
                    MessageBox.Show("Appointment ID, User ID, or Customer Name cannot be changed.");
                }                

                if (businessHour() == true && notOverlap() == true)
                {
                    //update type, end and start
                    con.Open();
                    string updateAppointment = "UPDATE appointment SET type = @TYPE, start = @START, end = @END WHERE appointmentId = @APPID";
                    cmd = new MySqlCommand(updateAppointment, con);
                    cmd.Parameters.AddWithValue("@TYPE", type);
                    cmd.Parameters.AddWithValue("@APPID", appointmentID);
                    cmd.Parameters.AddWithValue("@START", start);
                    cmd.Parameters.AddWithValue("@END", end);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    Clear();
                    DataGridViewFill();
                    con.Close();
                }
                else MessageBox.Show("Cannot update the appoinment.");
                
            }
            catch
            {
                MessageBox.Show("Unable to update the selected apppointment. Please check all the entered values.");
            }              
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Select the appointment ID to delete
            selectedRow = dataGridViewAppt.SelectedCells[0].RowIndex;
            DataGridViewRow selected = dataGridViewAppt.Rows[selectedRow];
            int appIDSelected = int.Parse(selected.Cells["Appointment ID"].Value.ToString());

            //delete the slected apppointment row
            con.Open();
            string deleteAppointment = "DELETE FROM appointment WHERE appointmentId = @APPID";
            cmd = new MySqlCommand(deleteAppointment, con);
            cmd.Parameters.AddWithValue("@APPID", appIDSelected);
            cmd.ExecuteNonQuery();            
            MessageBox.Show("Deleted Successfully");
            DataGridViewFill();
            Clear();
            con.Close();            
        }
        void Clear()
        {            
            appID.Text = custID.Text = customerName.Text = typeApp.Text = " ";

            startTime.Value = DateTime.Now;
            endTime.Value = DateTime.Now;

        }
        void DataGridViewFill()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();
                string sqlString = "SELECT appointmentId AS 'Appointment ID', appointment.customerId AS 'Customer ID', customer.customerName AS 'Customer Name', type AS 'Type', start AS 'Start Date', end AS 'End Date' FROM appointment, customer WHERE customer.customerId = appointment.customerId ORDER BY appointmentId ";
                MySqlCommand command = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewAppt.DataSource = dt;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Start Date"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["Start Date"], TimeZoneInfo.Local).ToString("yyyy-MM-dd HH:mm:ss");
                    dt.Rows[i]["End Date"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["End Date"], TimeZoneInfo.Local).ToString("yyyy-MM-dd HH:mm:ss");
                    
                    /*DateTime start = (DateTime)dt.Rows[i]["Start Date"];
                    dt.Rows[i]["Start Date"] = start.ToLocalTime();

                    DateTime end = (DateTime)dt.Rows[i]["End Date"];
                    dt.Rows[i]["End Date"] = end.ToLocalTime();*/
                }             
            }
            
        }
        private void AppointmentRecord_Load(object sender, EventArgs e)
        {
            Clear();
            DataGridViewFill();
        }
        private bool notOverlap()
        {
            bool isNotOverlap = true;
            DateTimeOffset start = TimeZoneInfo.ConvertTimeToUtc(startTime.Value);
            string startPicker = start.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime end = TimeZoneInfo.ConvertTimeToUtc(endTime.Value);
            string endPicker = end.ToString("yyyy-MM-dd HH:mm:ss");

            string sql1 = $"SELECT * FROM appointment WHERE appointmentId != '{appoinmentID}' AND start BETWEEN '{startPicker}' AND '{endPicker}'";
            string sql2 = $"SELECT * FROM appointment WHERE appointmentId != '{appoinmentID}' AND end BETWEEN '{startPicker}' AND '{endPicker}'";
            string sql3 = $"SELECT * FROM appointment WHERE appointmentId != '{appoinmentID}' AND start <= '{startPicker}' AND end >= '{endPicker}'";

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            using (MySqlConnection c = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {              
                MySqlCommand cmd1 = new MySqlCommand(sql1, c);
                MySqlCommand cmd2 = new MySqlCommand(sql2, c);
                MySqlCommand cmd3 = new MySqlCommand(sql3, c);

                con.Open();
                //create data adapter
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);

                //query database and return the result to datatable
                da1.Fill(dt1);
                da2.Fill(dt2);
                da3.Fill(dt3);     
                
                con.Close();                       
            }
            if (dt1.Rows.Count > 0 || dt2.Rows.Count > 0 || dt3.Rows.Count > 0)
            {                
                MessageBox.Show("Overlapping. Please select a different time.");
                isNotOverlap = false;         
            }
            else
            {
                isNotOverlap = true;
                appoinmentID = 0;
            }             

            return isNotOverlap;      
        }        

        //F. scheduling an appointment outside business hours
        private bool businessHour()
        {
            TimeSpan businessOpen = new TimeSpan(8, 0, 0);
            TimeSpan businessClose = new TimeSpan(17, 0, 0);           

            TimeSpan apptStartTime = startTime.Value.TimeOfDay;
            TimeSpan apptEndTime = endTime.Value.TimeOfDay;

            //business hours is from 8:00 to 17:00
            if (apptStartTime < businessOpen || apptEndTime > businessClose)
            {
                MessageBox.Show("Business hour is from 8:00 AM to 5:00 PM. Please enter a different time.");
                return false;
            } 
            else
                return true;
        }

        private void startTime_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void endTime_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var main = new Main();
            main.Show();
            Hide();
        }
        private void appType_Click(object sender, EventArgs e)
        {
            var type = new TypeReport();
            type.Show();
            Hide();
        }

        private void ClearTextbox_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
