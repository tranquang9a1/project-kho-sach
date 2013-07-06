using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace CocBook
{
    public partial class ConnectDBForm : Form
    {
        LogFile logger = new LogFile();
        public ConnectDBForm()
        {
            InitializeComponent();
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                CustomizeConnectionString();
                bool rs = TestConnectToDB();

                if (rs)
                {
                    LoginForm loginForm = new LoginForm();
                    this.Close();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối cơ sở dữ liệu. Vui lòng thử lại !");
                }
            }
            catch (Exception ex)
            {
                // Write Log File
                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void CustomizeConnectionString()
        {
            string cs;
            string dbName = txtDBName.Text;
            if (cbAuthentication.SelectedIndex == 0)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                
                cs = "Server=(local);Database = " + dbName + ";uid=" + username + ";pwd=" + password;
            }
            else
            {
                cs = "Data Source=(local); Initial Catalog="+dbName+"; Integrated Security=SSPI";
            }
            
            Properties.Settings.Default.connectionString = cs;
            Properties.Settings.Default.Save();
        }

        private bool TestConnectToDB()
        {
            try
            {
                string connect = Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(connect);
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Write Log File
                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");

                return false;
            }
        }
        private void cbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbAuthentication.SelectedIndex == 0)
                {
                    lbUsername.Text = "Login:";
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUsername.Text = "sa";
                }
                else
                {
                    lbUsername.Text = "Username:";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtPassword.Enabled = false;
                    txtUsername.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Write Log File
                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }


    }
}
