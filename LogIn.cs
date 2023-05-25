using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trang_Granville
{
    public partial class LogIn : Form
    {
        public delegate string greeting(string name);
        
        public LogIn()
        {
            InitializeComponent();
            Language();            
        }       
        private void signInButton_Click(object sender, EventArgs e)
        {
            string userName = usernameTextbox.Text;
            string password = passwordTextbox.Text;
            using (MySqlConnection c = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                c.Open();
                string query = $"SELECT userId FROM user WHERE userName = '{userName}' AND password = '{password}'";
                MySqlCommand cmd = new MySqlCommand(query, c);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                     this.Hide();
                    
                    //lambda expression
                    greeting obj = (name) => { return "Hello user" + name + ", welcome to the application"; };
                    string greeting = obj.Invoke(userName);
                    MessageBox.Show(greeting);                    
                   
                    Main m = new Main();

                    WriteLog(); // recording timestamps for login
                    ApptAlert(); //notify if appointment within 15 minutes
                    m.Show();                                       
                }
                else
                {
                    if(CultureInfo.CurrentCulture.TwoLetterISOLanguageName =="fr")
                    {
                        MessageBox.Show("Veuillez saisir le nom d'utilisateur et le mot de passe corrects.");
                    }
                    else
                    {
                        MessageBox.Show("Please enter the correct username and password.");
                    }                    
                }
            }         
        }
        private void Language()
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fr")
            {
                French();                
            }           
        }
        private void French()
        {
            label3.Text = "Incription";
            label1.Text = "Nom d'utilisateur";
            label2.Text = "Mot de passe";
            signInButton.Text = "S'identifier";
            cancelButton.Text = "Annuler";
            buttonExit.Text = "Quitter la candidature";
        }
        
        //alert 15 in advance of an appointment
        private void ApptAlert()
        {
            DateTime now = Convert.ToDateTime(DateTime.UtcNow);
            DateTime later = Convert.ToDateTime(DateTime.UtcNow).AddMinutes(15);

            string apptAlert = "SELECT appointmentId FROM appointment WHERE start BETWEEN '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + later.ToString("yyyy-MM-dd HH:mm:ss")+"';";
            
            using (MySqlConnection c = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                c.Open();
                MySqlCommand cmd = new MySqlCommand(apptAlert, c);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    MessageBox.Show("You have an upcomming appointment within the next 15 minutes.");
                }
                c.Close();
            }
        }

        //Tracking user activity
        private void WriteLog()
        {
            try
            {
                using (StreamWriter writer = File.AppendText("loginRecord.txt"))
                {
                    writer.WriteLine(usernameTextbox.Text + " successfully logged in at " + DateTime.Now);
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot record timestamps for users log-in.");
            }
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            usernameTextbox.Text = string.Empty;
            passwordTextbox.Text = string.Empty;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
