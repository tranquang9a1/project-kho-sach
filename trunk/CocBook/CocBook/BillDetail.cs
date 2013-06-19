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
    public partial class BillDetail : Form
    {
        public ImportExport importExport = new ImportExport();
        CustomerDAL customerDAL = new CustomerDAL();
        Customer customer = new Customer();
        public BillDetail()
        {
            
            InitializeComponent();
        }
        private void BillLoadData(){
            customer = customerDAL.GetCustomerbyName(importExport.CustomerName);
            lbTitle.Text = "Phiếu " + importExport.Type;
            txtCheckNo.Text = importExport.CheckNo.ToString();
            txtDay.Text = importExport.Date.ToString();//Edit type DD/MM/YYYY
            txtCustomerName.Text = customer.CustomerName;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
            txtTaxNo.Text = customer.TaxNo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            editrow.ieDetail.CheckNo = importExport.CheckNo;
            editrow.Show();
        }
    }
}
