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
        
        IEDetailDAL ieDAL = new IEDetailDAL();
        
        public BillDetail()
        {
            
            InitializeComponent();
            if (ieDAL.HasIEWithCheckNo(importExport.CheckNo))
            {
                OrderLoadData();
            }
        }
        private void OrderLoadData()
        {
            List<GridViewRow> list = new List<GridViewRow>();
            List<IEDetail> iedetail = new List<IEDetail>();
            iedetail = ieDAL.GetIEDetailByCheckNo(importExport.CheckNo);
            foreach (var item in iedetail)
            {
                GridViewRow gridViewRow = new GridViewRow();
                gridViewRow.ISBNBook = item.ISBNBook;
                book = bookDAL.GetBookbyISBN(item.ISBNBook);
                gridViewRow.BookName = book.BookName;
                gridViewRow.Unit = book.Unit;
                gridViewRow.Quantity = item.Quantity;
                gridViewRow.Price = book.Price;
                gridViewRow.Discount = item.Discount;
                gridViewRow.Value = item.Value;
                list.Add(gridViewRow);
            }
            dataGridView1.DataSource = list;            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            editrow.importRowEvent += new ImportRow(OrderLoadData);
            editrow.ieDetail.CheckNo = importExport.CheckNo;
            editrow.Add = true;
            editrow.ShowDialog();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            IEDetail iedetail = new IEDetail();
            editrow.ieDetail.CheckNo = importExport.CheckNo;
            iedetail.Discount = editrow.ieDetail.Discount;
            iedetail.Quantity = editrow.ieDetail.Quantity;
            editrow.ShowDialog();
        }
        /*
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
        */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            IEDetail iedetail = new IEDetail();
            bool del = ieDAL.DeletePublisherByCheckNoAndISBN(iedetail.CheckNo, iedetail.ISBNBook);
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
        public void AutoNumberRowsForGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                for (int count = 0; (count <= (dataGridView.Rows.Count - 2)); count++)
                {
                    dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                }
            }
        }

    }
    public class GridViewRow
    {
        public string ISBNBook { get; set; }
        public string BookName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Value { get; set; }
    }

}
