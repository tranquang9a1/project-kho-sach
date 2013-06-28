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
        public bool add { get; set; }
        ImportExportDAL importExportDAL = new ImportExportDAL();
        CustomerManage customerManage = new CustomerManage();
        public Customer customer = new Customer();
        BillDetail billDetail = new BillDetail();
        public InfoDetail()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            if (!add)
            {
                txtCheckNo.Text = importExport.CheckNo.ToString();
                txtCheckNo.ReadOnly = true;
                txtDay.Text = String.Format("{0:dd/MM/yyyy}", importExport.Date);
                if (String.Compare(importExport.ImEx, "Nhập", true) == 0)
                {
                    rdImport.Checked = true;
                }
                else
                {
                    rdExport.Checked = true;
                }
                if (String.Compare(importExport.Type, "Ký gửi", true) == 0)
                {
                    cbType.SelectedIndex = 0;
                }
                if (String.Compare(importExport.Type, "Bán lẻ", true) == 0)
                {
                    cbType.SelectedIndex = 1;
                }
                if (String.Compare(importExport.Type, "Nhập trả", true) == 0 && String.Compare(importExport.ImEx, "Nhập", true) == 0)
                {
                    cbType.SelectedIndex = 2;
                }
                if (String.Compare(importExport.Type, "Lưu kho", true) == 0 && String.Compare(importExport.ImEx, "Xuất", true) == 0)
                {
                    cbType.SelectedIndex = 2;
                }
                if (String.Compare(importExport.Type, "Trả hàng", true) == 0 && String.Compare(importExport.ImEx, "Xuất", true) == 0)
                {
                    cbType.SelectedIndex = 3;
                }
                txtCustomerName.Text = customer.CustomerName;
            }
            else
            {
                txtCheckNo.ReadOnly = false;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (add == true)
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
                    importExport.Date = DateTime.ParseExact(txtDay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thời gian dạng 25/12/1993 !");
                    txtDay.Focus();
                }

                if (rdImport.Checked)
                {
                    importExport.ImEx = "Nhập";
                }
                else if (rdExport.Checked)
                {
                    importExport.ImEx = "Xuất";
                }
                importExport.Type = cbType.SelectedItem.ToString();
                if (txtCustomerName != null)
                {
                    importExport.CustomerID = customer.CustomerID;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng. Vui lòng chọn!");
                    txtCustomerName.Focus();
                }
                importExportDAL.CreateIE(importExport);
                
            }
            else 
            {
                importExportDAL.UpdateIE(importExport);
            }
            billDetail.importExport = this.importExport;
            billDetail.OrderLoadData();
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
            cbType.Items.Add("Trả hàng");
        }
    }
}
