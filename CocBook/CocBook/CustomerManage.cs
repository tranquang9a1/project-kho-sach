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
    public delegate void LoadCustomerName();
    public partial class CustomerManage : Form
    {
        LogFile logger = new LogFile();
        public event LoadCustomerName loadCustomerNameEvent;
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
            try
            {
                CustomerDetail customerDetail = new CustomerDetail();
                customerDetail.Add = true;
                customerDetail.NotifyEvent += new Notify(CustomerDetail_NotifyEvent);
                customerDetail.Show();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        void CustomerDetail_NotifyEvent()
        {
            loadAllData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDetail customerDetail = new CustomerDetail();
                customerDetail.customer = customer;
                customerDetail.Add = false;
                customerDetail.LoadData();
                customerDetail.NotifyEvent += new Notify(CustomerDetail_NotifyEvent);
                customerDetail.Show();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int customerID = (int)CustomerDataGridView.SelectedRows[0].Cells[0].Value;
                    CustomerDAL customerDAL = new CustomerDAL();
                    customerDAL.DeleteCustomer(customerID);
                }
                loadAllData();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void CustomerDataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                customer.CustomerID = (int)CustomerDataGridView.SelectedRows[0].Cells[0].Value;
                customer.CustomerName = CustomerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                customer.Address = CustomerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                customer.Phone = CustomerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                customer.TaxNo = CustomerDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                if (customer.CustomerName != null)
                {
                    if (loadCustomerNameEvent != null)
                    {
                        loadCustomerNameEvent();
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng! Vui lòng chọn lại !");
                    this.Focus();
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

    }
}
