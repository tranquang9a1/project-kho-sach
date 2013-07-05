using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.cs.DAL;
using DataAccessLayer.cs.DTO;

namespace CocBook
{
    public partial class LoginForm : Form
    {
        LogFile logger = new LogFile();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUsername.Text.ToString();
                string passWord = txtPassword.Text.ToString();
                UserInfoDAL userInfoDAL = new UserInfoDAL();
                bool rs = userInfoDAL.IsLogin(userName, passWord);
                if (rs)
                {
                    MainMenuForm main = new MainMenuForm();
                    main.Show();
                    this.Close();
                }
                else
                {
                    txtUsername.Focus();
                    MessageBox.Show("Đăng nhập thất bại !");
                }                
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
    }
}
