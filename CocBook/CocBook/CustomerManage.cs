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
    public partial class CustomerManage : Form
    {
        public Customer customer = new Customer();
        public CustomerManage()
        {
            InitializeComponent();
            loadAllData();
        }
        public void loadAllData()
        {
            CustomerDAL cusDAL = new CustomerDAL();
            List<Customer> list = cusDAL.GetAllCustomer();
            CustomerDataGridView.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerDetail customerDetail = new CustomerDetail();
            customerDetail.Add = true;
            customerDetail.NotifyEvent += new Notify(CustomerDetail_NotifyEvent);
            customerDetail.Show();
        }

        void CustomerDetail_NotifyEvent()
        {
            loadAllData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CustomerDetail customerDetail = new CustomerDetail();
            customerDetail.customer = customer;
            customerDetail.Add = false;
            customerDetail.LoadData();
            customerDetail.NotifyEvent += new Notify(CustomerDetail_NotifyEvent);
            customerDetail.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string name = CustomerDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                BookDAL bookDAL = new BookDAL();
                bookDAL.DeleteBook(name);
            }
            loadAllData();
        }

        private void CustomerDataGridView_Click(object sender, EventArgs e)
        {
            customer.CustomerName = CustomerDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            customer.Address = CustomerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            customer.Phone = CustomerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            customer.TaxNo = CustomerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                Close();
            }
        }

    }
}
