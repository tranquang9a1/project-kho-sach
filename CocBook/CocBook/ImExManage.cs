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
            List<ImportExport> list1 = new List<ImportExport>();
            List<LoadResult> list2 = new List<LoadResult>();
            ImportExportDAL importexportDAL = new ImportExportDAL();
            LoadResult loadResult = new LoadResult();
            list1 = importexportDAL.GetAllIE();
            foreach (var ie in list1)
            {
                CustomerDAL customerDAL = new CustomerDAL();
                loadResult.CheckNo = ie.CheckNo;
                loadResult.Date = ie.Date;
                loadResult.Type = ie.Type;
                loadResult.ImEx = ie.ImEx;
                loadResult.CustomerName = customerDAL.GetCustomerbyID(ie.CustomerID).CustomerName;
                list2.Add(loadResult);
            }
            dataGridView1.DataSource = list2;
        }
    }
    public class LoadResult
    {
        public int CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string ImEx { get; set; }
        public string CustomerName { get; set; }
    }
}
