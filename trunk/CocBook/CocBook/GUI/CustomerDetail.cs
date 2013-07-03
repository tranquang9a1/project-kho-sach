﻿using System;
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
        LogFile logger = new LogFile();
        public bool Add { get; set; }
        public Customer customer = new Customer();
        public event Notify NotifyEvent;
        public CustomerDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Hãy nhập tên");
                    txtName.Focus();
                }
                else
                {
                    customer.CustomerName = txtName.Text;
                }
                customer.Address = txtAddress.Text;
                customer.Phone = txtPhone.Text;
                customer.TaxNo = txtTaxNo.Text;
                if (Add)
                {
                    customerDAL.CreateCustomer(customer);
                }
                else
                {
                    customerDAL.UpdateCustomer(customer);
                }
                if (NotifyEvent != null)
                {
                    NotifyEvent();
                }
                Close();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        public void LoadData()
        {
            try
            {
                if (!Add)
                {
                    txtName.Text = customer.CustomerName;
                    txtAddress.Text = customer.Address;
                    txtPhone.Text = customer.Phone;
                    txtTaxNo.Text = customer.TaxNo;
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }

            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
