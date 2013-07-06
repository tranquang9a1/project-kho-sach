using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CocBook
{
    public partial class MainMenuForm : Form
    {
        LogFile logger = new LogFile();
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtBookManage_Click(object sender, EventArgs e)
        {
            BookManage bookManageForm = new BookManage(true);
            bookManageForm.Show();
        }

        private void txtViewMainStore_Click(object sender, EventArgs e)
        {
            ViewStore viewMainStore = new ViewStore();
            viewMainStore.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImExManage consignImport = new ImExManage();
            consignImport.Show();
        }
    }
}
