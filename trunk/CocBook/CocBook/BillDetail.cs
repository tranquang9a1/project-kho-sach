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
using DataAccessLayer.DAL;

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
        IEDetail iedetail = new IEDetail();
        public BillDetail()
        {
            InitializeComponent();
            iedetail.CheckNo = importExport.CheckNo;
        }
        public void OrderLoadData()
        {
            iedetail.CheckNo = importExport.CheckNo;
            List<GridViewRow> list = new List<GridViewRow>();
            List<IEDetail> iedetail1 = new List<IEDetail>();
            iedetail1 = ieDAL.GetIEDetailByCheckNo(importExport.CheckNo);
            foreach (var item in iedetail1)
            {
                GridViewRow gridViewRow = new GridViewRow();
                gridViewRow.ISBNBook = item.ISBNBook;
                Book book1 = new Book();
                book1 = bookDAL.GetBookbyISBN(item.ISBNBook);
                gridViewRow.BookName = book1.BookName;
                gridViewRow.Unit = book1.Unit;
                gridViewRow.Quantity = item.Quantity;
                gridViewRow.Price = book1.Price;
                gridViewRow.Discount = item.Discount;
                gridViewRow.Value = item.Value;
                list.Add(gridViewRow);
            }
            dataGridView1.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            editrow.ieDetail.CheckNo = importExport.CheckNo;
            editrow.Add = true;
            editrow.importRowEvent += new ImportRow(OrderLoadData);
            editrow.ShowDialog();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRow editrow = new EditRow();
            editrow.ieDetail = iedetail;
            editrow.book = book;
            editrow.Add = false;
            editrow.LoadData();
            editrow.importRowEvent += new ImportRow(editrow_importRowEvent);
            editrow.ShowDialog();
        }

        void editrow_importRowEvent()
        {
            OrderLoadData();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //id grid = 0;
            iedetail.ISBNBook = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            book.ISBNBook = iedetail.ISBNBook;
            book.BookName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            book.Unit = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            iedetail.Quantity = (int)dataGridView1.SelectedRows[0].Cells[4].Value;
            book.Price = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
            iedetail.Discount = (int)dataGridView1.SelectedRows[0].Cells[6].Value;
            iedetail.Value = (int)dataGridView1.SelectedRows[0].Cells[7].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool del = ieDAL.DeleteOrderByCheckNoAndISBN(importExport.CheckNo, iedetail.ISBNBook);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateStore();
        }
        private void UpdateStore()
        {
            bool rs = true;
            int rows;
            string error = "";
            for (rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                BookStore bookStore = new BookStore();
                BookStoreDAL bookStoreDAL = new BookStoreDAL();
                string ISBN = dataGridView1.Rows[rows].Cells[1].Value.ToString();
                int Quantity = (int)dataGridView1.Rows[rows].Cells[4].Value;

                bookStore = bookStoreDAL.GetBookStorebyISBNBook(ISBN);
                if (bookStore == null)
                {
                    if (String.Compare(importExport.ImEx, "Nhập", true) == 0)
                    {
                        BookStore bookStore1 = new BookStore();
                        bookStore1.ISBN = ISBN;
                        bookStore1.Quantity = Quantity;
                        rs = bookStoreDAL.CreateBookStore(bookStore1);
                        if (!rs)
                        {
                            error = "Không thể thêm sách tại dòng " + rows;
                            break;
                        }
                    }
                    else
                    {
                        rs = false;
                        error = "Không thể xuất sách không có trong kho";
                        break;
                    } 
                }
                else
                {
                    if (String.Compare(importExport.ImEx, "Nhập", true) == 0)
                    {
                        bookStore.Quantity += Quantity;
                    }
                    else
                    {
                        if (bookStore.Quantity >= Quantity)
                        {
                            bookStore.Quantity -= Quantity;
                        }
                        else
                        {
                            rs = false;
                            error = "Số lượng sách tại dòng " + rows + " lớn hơn số lượng có trong kho";
                            break;
                        }
                    }

                    rs = bookStoreDAL.UpdateBookStore(bookStore);
                    if (!rs)
                    {
                        error = "Không thể cập nhật sách tại dòng " + rows;
                        break;
                    }
                }

            }
            if (!rs)
            {
                MessageBox.Show(error + ". Vui lòng xem lại !");
            }
            else
            {
                MessageBox.Show("Cập nhật xuống kho thành công !");
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
