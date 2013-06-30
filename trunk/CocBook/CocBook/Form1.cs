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

namespace CocBook
{
    public partial class ConnectDBForm : Form
    {
        LogFile logger = new LogFile();
        public ConnectDBForm()
        {
            InitializeComponent();
        }
        public bool ChangConnectionString(string Name, string value, string AppName)
        {
            bool retVal = false;
            try
            {
                //The application configuration file name
                string FILE_NANME = string.Concat(Application.StartupPath, "\\", AppName.Trim(), ".exe.Config");
                XmlTextReader reader = new XmlTextReader(FILE_NANME);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                string nodeRoute = string.Concat("connectionStrings/add");

                XmlNode cnnStr = null;
                XmlElement root = doc.DocumentElement;
                XmlNodeList Settings = root.SelectNodes(nodeRoute);

                for (int i = 0; i < Settings.Count; i++)
                {
                    cnnStr = Settings[i];
                    if (cnnStr.Attributes["name"].Value.Equals(Name))
                        break;
                    cnnStr = null;
                }

                cnnStr.Attributes["connectionString"].Value = value;
                doc.Save(FILE_NANME);
                retVal = true;
            }
            catch (Exception ex)
            {
                // Write Log File
                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
                retVal = false;
            }
            return retVal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs;
                if (comboBox1.SelectedIndex == 0)
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    string cs = "Server=(local);Database = CocBook;uid=" + username + ";pwd=" + password;
                    ChangConnectionString("BookStoreCS", cs, "CocBook");
                }
                else
                {
                    string cs = "Data Source=(local); Initial Catalog=CocBook; Integrated Security=SSPI";
                    ChangConnectionString("BookStoreCS", cs, "CocBook");
                }
                try
                {
                    //Test connect to DB
                    string connect = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(connect);
                    con.Open();
                    rs = true;
                }
                catch (Exception)
                {
                    rs = false ;
                }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    lbUsername.Text = "Login:";
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUsername.Text = "sa";
                }
                else
                {
                    lbUsername.Text = "Username:";
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
