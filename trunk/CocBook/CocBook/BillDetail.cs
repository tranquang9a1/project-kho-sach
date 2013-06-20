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
        Book book = new Book();
        BookDAL bookDAL = new BookDAL();
        IEDetail iedetail = new IEDetail();
        IEDetailDAL ieDAL = new IEDetailDAL();
        List<ListGridView> list = new List<ListGridView>();
        public BillDetail()
        {
            
            InitializeComponent();
            BillLoadData();
            OrderLoadData();
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
        private void OrderLoadData()
        {
            
            
            book = bookDAL.GetBookbyISBN(iedetail.ISBNBook);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            editrow.ieDetail.CheckNo = importExport.CheckNo;
            editrow.ShowDialog();
            editrow.totalCost += new TotalCost(editrow_totalCost);

        }

        void editrow_totalCost()
        {
            OrderLoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            editrow.ieDetail.CheckNo = importExport.CheckNo;
            iedetail.Discount = editrow.ieDetail.Discount;
            iedetail.Quantity = editrow.ieDetail.Quantity;
            editrow.ShowDialog();
            editrow.totalCost += new TotalCost(editrow_totalCost);
            

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //id grid = 0;
            iedetail.ISBNBook = dataGridView1.SelectedRows[1].Cells[1].Value.ToString();
            book.BookName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            book.Unit = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            iedetail.Quantity = (int)dataGridView1.SelectedRows[4].Cells[3].Value;
            book.Price = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
            iedetail.Discount = (int)dataGridView1.SelectedRows[0].Cells[6].Value;
            iedetail.Value = (int)dataGridView1.SelectedRows[0].Cells[7].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            bool del = ieDAL.DeletePublisherByCheckNoAndISBN(int.Parse(txtCheckNo.Text), iedetail.ISBNBook);
            if (del)
            {
                MessageBox.Show("Đã xóa!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra lại.");
            }
            OrderLoadData();
        }

    }
    public class ListGridView ()
    {
        public int i { get; set; }
        public string ISBNBook { get; set; }
        public string BookName { get; set; }
        public string Unit { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Value { get; set; }

    }

}
