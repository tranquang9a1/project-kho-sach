using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.cs.DTO;
using DataAccessLayer.cs.DAL;

namespace CocBook
{
    public partial class ImExManage : Form
    {
        public ImExManage()
        {
            InitializeComponent();
            LoadAllData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InfoDetail infoDetail = new InfoDetail();            
            infoDetail.Show();
            this.Close();
        }
        private void LoadAllData()
        {
            List<ImportExport> list = new List<ImportExport>();
            ImportExportDAL importexportDAL = new ImportExportDAL();
            list = importexportDAL.GetAllIE();
            dataGridView1.DataSource = list;
        }

    }
}
