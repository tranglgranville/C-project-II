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
    public partial class CustomerRecord : Form
    {
        public delegate string alertDelete(string name);
        
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
        MySqlCommand cmd;

        int countryID = 0;
        int addressID = 0;
        int cityID = 0;        

        public CustomerRecord()
        {
            InitializeComponent();
            DataGridViewFill();            
        }

        public int selectedRow;       
        
        private void dataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dataGridViewCustomer.SelectedCells[0].RowIndex;
            DataGridViewRow selected = dataGridViewCustomer.Rows[selectedRow];

            customerID.Text = selected.Cells["Customer ID"].Value.ToString();
            customerName.Text = selected.Cells["Customer Name"].Value.ToString();
            phone.Text = selected.Cells["Phone"].Value.ToString();

            int addressID = int.Parse(selected.Cells["Address ID"].Value.ToString());
            //int cityID = 0; //unassigned local variable
            int countryID = 0;

            //find address
            con.Open();
            string add = $"SELECT * FROM address WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(add, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                address1.Text = reader.GetString("address");
                address2.Text = reader.GetString("address2");
                zipcode.Text = reader.GetString("postalCode");
                //cityID = reader.GetInt32("cityId");
            }
            else
            {
                address1.Text = string.Empty;
                address2.Text = string.Empty;
                zipcode.Text = string.Empty;
            }
            con.Close();
            
            //find city
            con.Open();
            string cityData = $"SELECT * FROM city WHERE cityId = '{cityID}'";
            cmd = new MySqlCommand(cityData, con);
            MySqlDataReader cityReader = cmd.ExecuteReader();
            if (cityReader.Read())
            {
                //cityID = cityReader.GetInt32(0);
                city.Text = cityReader.GetString("city");
                countryID = cityReader.GetInt32("countryId");
            }
            else
            {
                city.Text = string.Empty;
            }
            con.Close();
            
            //find country
            con.Open();
            string countryData = $"SELECT * FROM country WHERE countryId = '{countryID}'";
            cmd = new MySqlCommand(countryData, con);
            MySqlDataReader countryReader = cmd.ExecuteReader();
            if (countryReader.Read())
            {
                countryID = countryReader.GetInt32(0);
                countryList.Text = countryReader.GetString("country");
            }
            else
            {
                countryList.Text = string.Empty;
            }            
            con.Close();
        }
        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nameAdd = customerName.Text;
                string address1Add = address1.Text;
                string address2Add = address2.Text;
                string cityAdd = city.Text;
                string countryAdd = countryList.Text;
                string zipAdd = zipcode.Text;
                string phoneAdd = phone.Text;
                int addressId = 0;
                int cityId = 0;

                //retrieve cityId from the selected city                
                using (MySqlConnection c = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    string citydata = $"SELECT * FROM city WHERE city = '{cityAdd}'";
                    c.Open();
                    using(MySqlCommand commandCity = new MySqlCommand(citydata, c))
                    {
                        MySqlDataReader cityReader = commandCity.ExecuteReader();
                        if (cityReader.Read())
                        {
                            cityId = cityReader.GetInt32(0);
                        }
                        else MessageBox.Show("Selected city is not in the list. Please select another city.");
                    }
                    c.Close();

                }
                
                // insert cityId to the address table & create the new addressId
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    string insertaddress = "INSERT INTO address VALUES(NULL, @ADDRESS1, @ADDRESS2, @CITYID, @ZIP, @PHONE, @CREATEDATE, 'xx', @LASTUPDATE, 'xx')";
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(insertaddress, connection))
                    {
                        //cmd = new MySqlCommand(insertaddress, con);
                        command.Parameters.AddWithValue("@ADDRESS1", address1Add);
                        command.Parameters.AddWithValue("@ADDRESS2", address2Add);
                        command.Parameters.AddWithValue("@CITYID", cityId);
                        command.Parameters.AddWithValue("@ZIP", zipAdd);
                        command.Parameters.AddWithValue("@PHONE", phoneAdd);
                        command.Parameters.AddWithValue("@CREATEDATE", TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@LASTUPDATE", TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));
                        command.ExecuteNonQuery();
                        addressId = (int)command.LastInsertedId;
                    }
                    connection.Close();
                }

                //insert addressId to the customer table
                using (MySqlConnection connect = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    string insertcustomer = "INSERT INTO customer VALUES(NULL, @NAME, @ADDRESSID, 1, @CREATEDATE, 'xx', @LASTUPDATE, 'xx')";
                    connect.Open();
                    using (MySqlCommand comm = new MySqlCommand(insertcustomer, connect))
                    {                        
                        comm.Parameters.AddWithValue("@NAME", nameAdd);
                        comm.Parameters.AddWithValue("@ADDRESSID", addressId);
                        comm.Parameters.AddWithValue("@CREATEDATE", TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@LASTUPDATE", TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.ExecuteNonQuery();
                    }
                    connect.Close();
                }
                
                MessageBox.Show("Updated Successfully");
                Clear();
                DataGridViewFill();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Unable to add the customer information. Please try again.");
            }
                       
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nameUpdate = customerName.Text;
                string address1Update = address1.Text;
                string address2Update = address2.Text;
                string cityUpdate = city.Text;
                string countryUpdate = countryList.Text;
                string zipUpdate = zipcode.Text;
                string phoneUpdate = phone.Text;
                int addressIdUpdate = 0;

                ///////////////////////
                selectedRow = dataGridViewCustomer.SelectedCells[0].RowIndex;
                DataGridViewRow selected = dataGridViewCustomer.Rows[selectedRow];
                int addressID = int.Parse(selected.Cells["Address ID"].Value.ToString()); //getting addressID
                con.Open();
                string add = $"SELECT * FROM address WHERE addressId = '{addressID}'";
                cmd = new MySqlCommand(add, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cityID = reader.GetInt32("cityId"); // getting cityID
                }
                con.Close();

                //////////////////////
                con.Open();
                string countryDa = $"SELECT * FROM country WHERE countryId = '{countryID}'";
                cmd = new MySqlCommand(countryDa, con);
                MySqlDataReader countryRead = cmd.ExecuteReader();
                if (countryRead.Read())
                {
                    countryID = countryRead.GetInt32(0);   //getting countryID             
                }
                con.Close();

                // update country table
                con.Open();
                string updateCountry = "UPDATE country SET country = @COUNTRY WHERE countryId = @COUNTRYID";
                cmd = new MySqlCommand(updateCountry, con);
                cmd.Parameters.AddWithValue("@COUNTRY", countryUpdate);
                cmd.Parameters.AddWithValue("@COUNTRYID", countryID);
                cmd.ExecuteNonQuery();
                string countryData = $"SELECT * FROM country WHERE country = '{countryUpdate}'"; //getting new countryId from updated country
                cmd = new MySqlCommand(countryData, con);
                MySqlDataReader countryReader = cmd.ExecuteReader();
                if (countryReader.Read())
                {
                    countryID = countryReader.GetInt32(0);
                }
                con.Close();

                //update city table based on new countryID
                con.Open();
                string updateCity = "UPDATE city SET city = @CITY WHERE cityId = @CITYID";
                cmd = new MySqlCommand(updateCity, con);
                cmd.Parameters.AddWithValue("@CITY", cityUpdate);
                cmd.Parameters.AddWithValue("@CITYID", cityID);
                cmd.ExecuteNonQuery();
                string cityData = $"SELECT * FROM city WHERE city = '{cityUpdate}'"; //getting new cityId from updated city
                cmd = new MySqlCommand(cityData, con);
                MySqlDataReader cityReader = cmd.ExecuteReader();
                if (cityReader.Read())
                {
                    cityID = cityReader.GetInt32(0);
                }
                con.Close();
                
                //update address table
                con.Open();
                string updateAddress = "UPDATE address SET address = @ADDRESS1, address2 = @ADDRESS2, postalCode = @ZIPCODE, phone = @PHONE WHERE addressId = @ADDRESSID";
                cmd = new MySqlCommand(updateAddress, con);
                cmd.Parameters.AddWithValue("@ADDRESS1", address1Update);
                cmd.Parameters.AddWithValue("@ADDRESS2", address2Update);
                cmd.Parameters.AddWithValue("@ZIPCODE", zipUpdate);
                cmd.Parameters.AddWithValue("@PHONE", phoneUpdate);
                cmd.Parameters.AddWithValue("@ADDRESSID", addressID); //addressId is still keeping the same
                cmd.ExecuteNonQuery();
                con.Close();

                //update customer table
                con.Open();
                string updateCustomer = "UPDATE customer SET customerName = @CUSTOMERNAME WHERE customerId = @CUSTOMERID";
                cmd = new MySqlCommand(updateCustomer, con);
                cmd.Parameters.AddWithValue("@CUSTOMERNAME", nameUpdate);
                cmd.Parameters.AddWithValue("@CUSTOMERID", customerID.Text); //customerId is still keeping the same
                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully");
                Clear();
                DataGridViewFill();
                con.Close();

            }
            catch
            {
                MessageBox.Show("Unable to update the customer information. Please try again.");
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {            
            selectedRow = dataGridViewCustomer.SelectedCells[0].RowIndex;
            DataGridViewRow selected = dataGridViewCustomer.Rows[selectedRow];
            int customerID = int.Parse(selected.Cells["Customer ID"].Value.ToString());

            //lambda expression
            alertDelete obj = (name) => { return "The customer ID: " + name + " will be deleted."; };
            string deleteCustomer = obj.Invoke(customerID.ToString());
            MessageBox.Show(deleteCustomer);

            con.Open();
            string deletecustomer = "DELETE FROM customer WHERE customerId = @CUSTOMERID";
            cmd = new MySqlCommand(deletecustomer, con);
            cmd.Parameters.AddWithValue("@CUSTOMERID", customerID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delected Successfully");
            Clear();
            DataGridViewFill();
            con.Close();            
        }
        void Clear()
        {
            customerID.Text = customerName.Text = address1.Text = address2.Text = city.Text = countryList.Text = zipcode.Text = phone.Text = " ";            
        }
        void DataGridViewFill()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                con.Open();
                string sqlString = "SELECT customerId AS 'Customer ID', customerName AS 'Customer Name', customer.addressId AS 'Address ID',  " +
                "phone AS 'Phone' FROM customer, address WHERE customer.addressId = address.addressId ";
                MySqlCommand command = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewCustomer.DataSource = dt;                
            }
        }

        private void customerReport_Click(object sender, EventArgs e)
        {
            var report = new CustomerReport();
            report.Show();
            Hide();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            var main = new Main();
            main.Show();
            Hide();
        }

        private void ClearTextbox_Click(object sender, EventArgs e)
        {
            customerID.Text = String.Empty;
            customerName.Text = String.Empty;
            address1.Text = String.Empty;
            address2.Text = String.Empty;
            city.Text = String.Empty;
            countryList.Text = String.Empty;
            zipcode.Text = String.Empty;
            phone.Text = String.Empty;
        }
    }
}
