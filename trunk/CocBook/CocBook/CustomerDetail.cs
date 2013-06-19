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
    public delegate void Notify();
    public partial class CustomerDetail : Form
    {
        public bool Add { get; set; }
        public Customer customer = new Customer();
        public event Notify NotifyEvent;
        public CustomerDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            if (Add)
            {
               
                
                if (txtName.Text == "")
                {
                    MessageBox.Show("Hãy nhập tên");
                    txtName.Focus();
                }
                else
                {
                    customer.CustomerName = txtName.Text;
                }
                
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Hãy nhập địa chỉ !");
                    txtAddress.Focus();
                }
                else
                {
                    customer.Address = txtAddress.Text;
                    customer.Phone = txtPhone.Text;
                    customer.TaxNo = txtTaxNo.Text;
                    customerDAL.CreateCustomer(customer);
                    
                }
                }
            else
            {
                customer.Address = txtAddress.Text;
                customer.Phone = txtPhone.Text;
                customer.TaxNo = txtTaxNo.Text;
                customerDAL.UpdateCustomer(customer);
            }
            if (NotifyEvent != null)
            {
                NotifyEvent();
            }
            Close();
        }
        public void LoadData()
        {
            if (!Add)
            {
                txtName.Text = customer.CustomerName;
                txtAddress.Text = customer.Address;
                txtPhone.Text = customer.Phone;
                txtTaxNo.Text = customer.TaxNo;
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
