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
using System.Globalization;

namespace CocBook
{
    public partial class InfoDetail : Form
    {
        public ImportExport importExport = new ImportExport();
        ImportExportDAL importExportDAL = new ImportExportDAL();
        public InfoDetail()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            importExport.CheckNo = int.Parse(txtCheckNo.Text);
            importExport.Date = DateTime.ParseExact(txtDay.Text, "YYYY-MM-DD",CultureInfo.InvariantCulture);
            importExport.Type = cbType.SelectedItem.ToString();//Edit if Import Khác = Nhập trả; Export Khác = Lưu kho
            importExport.CustomerName = txtCustomerName.Text;
            importExportDAL.CreateIE(importExport);
            BillDetail billDetail = new BillDetail();
            billDetail.importExport = this.importExport;
            billDetail.Show();
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerManage customerManage = new CustomerManage();
            customerManage.Show();
            //After Choose Customer from CustomerManage Load CustomerName from Customer in CustomerManage
        }
    }
}
