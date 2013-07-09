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
using System.Data.SqlClient;

namespace CocBook
{
    public delegate void LoadCustomerName();
    public partial class CustomerManage : Form
    {
        LogFile logger = new LogFile();
        public event LoadCustomerName loadCustomerNameEvent;
        public Customer customer = new Customer();
        bool isAdd = false;

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
                groupBoxDetail.Enabled = true;
                ClearAll();
                isAdd = true;
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        private void ClearAll()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtTaxNo.Text = "";
        }

        void CustomerDetail_NotifyEvent()
        {
            loadAllData();
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
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Vui lòng xóa toàn bộ các đơn hàng của khách hàng này trước khi xóa !");
                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + sqlEx.Message + "'");
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
                isAdd = false;

                customer.CustomerID = (int)CustomerDataGridView.SelectedRows[0].Cells[0].Value;
                customer.CustomerName = CustomerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                customer.Address = CustomerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                customer.Phone = CustomerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                customer.TaxNo = CustomerDataGridView.SelectedRows[0].Cells[4].Value.ToString();

                
                txtName.Text = CustomerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = CustomerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = CustomerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                txtTaxNo.Text = CustomerDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                groupBoxDetail.Enabled = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SaveToDB();
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }

        }
        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Hãy nhập tên");
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void SaveToDB()
        {
            customer.CustomerName = txtName.Text;
            customer.Address = txtAddress.Text;
            customer.Phone = txtPhone.Text;
            customer.TaxNo = txtTaxNo.Text;
            CustomerDAL customerDAL = new CustomerDAL();
            bool rs;
            if (isAdd)
            {
                rs = customerDAL.CreateCustomer(customer);
            }
            else
            {
                rs = customerDAL.UpdateCustomer(customer);
            }
            if (rs)
            {
                MessageBox.Show("Đã lưu !");
                loadAllData();
            }
            else
            {
                MessageBox.Show("Không thể lưu !");
            }
        }
    }
}
