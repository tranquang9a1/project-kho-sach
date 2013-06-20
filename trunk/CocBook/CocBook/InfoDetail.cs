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
        CustomerManage customerManage = new CustomerManage();
        Customer customer = new Customer();
        BillDetail billDetail = new BillDetail();
        public InfoDetail()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtCheckNo.Text != null)
            {
                importExport.CheckNo = int.Parse(txtCheckNo.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa điền số phiếu! Vui lòng nhập lại! ");
                txtCheckNo.Focus();
            }
            if (txtDay.Text != null)
            {
                importExport.Date = DateTime.ParseExact(txtDay.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thời gian dạng YYYY-MM-DD !");
                txtDay.Focus();
            }
            
            if (rdImport.Checked)
            {
                importExport.ImEx = "I";
            }
            else if (rdExport.Checked)
            {
                importExport.ImEx = "E";
            }
            importExport.Type = cbType.SelectedItem.ToString();
            if (txtCustomerName != null)
            {
                importExport.CustomerName = txtCustomerName.Text;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng. Vui lòng chọn!");
                txtCustomerName.Focus();
            }
            
            importExportDAL.CreateIE(importExport);
            
            billDetail.importExport = this.importExport;
            billDetail.Show();
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            
            customerManage.loadCustomerNameEvent += new LoadCustomerName(loadCustomerName);
            customerManage.ShowDialog();
            
        }
        void loadCustomerName()
        {
            customer = customerManage.customer;
            txtCustomerName.Text = customer.CustomerName.ToString();
        }

        private void rdImport_CheckedChanged(object sender, EventArgs e)
        {
            cbType.Items.Clear();
            cbType.Items.Add("Ký gửi");
            cbType.Items.Add("Bán lẻ");
            cbType.Items.Add("Nhập trả");
        }

        private void rdExport_CheckedChanged(object sender, EventArgs e)
        {
            cbType.Items.Clear();
            cbType.Items.Add("Ký gửi");
            cbType.Items.Add("Bán lẻ");
            cbType.Items.Add("Lưu kho");
        }
    }
}
