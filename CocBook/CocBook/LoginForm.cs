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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text.ToString();
            string passWord = txtPassword.Text.ToString();
            UserInfoDAL userInfoDAL = new UserInfoDAL();
            List<UserInfo> result = new List<UserInfo>();
            // Get all account info
            result = userInfoDAL.GetAllUserInfo();
            bool flag = true;
            // Scan all account
            foreach (var userinfo in result)
            {
                if (String.Compare(userinfo.Username, txtUsername.Text, true) == 0)
                {
                    if (String.Compare(userinfo.Password, txtPassword.Text, true) == 0)
                    {
                        flag = false;
                        MainMenuForm main = new MainMenuForm();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu sai. Vui lòng nhập lại !");
                        txtPassword.Focus();
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                MessageBox.Show("Không tồn tại tài khoản này !");
                txtUsername.Focus();
            }
        }
    }
}
