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
    public partial class BookManage : Form
    {
        Book book = new Book();
        public BookManage()
        {
            InitializeComponent();
            LoadAllData();
        }
        public void LoadAllData()
        {
            BookDAL BookDAL = new BookDAL();
            List<Book> list = BookDAL.GetAllBook();

            BookGridView.DataSource = list;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookDetail bookDetail = new BookDetail();
            bookDetail.Add = true;
            bookDetail.NotifyEvent += new NotifyLoadData(BookDetail_NotifyEvent);
            bookDetail.Show();
            
        }

        void BookDetail_NotifyEvent()
        {
           LoadAllData();
        }

       private void btnEdit_Click(object sender, EventArgs e)
        {
            BookDetail bookDetail = new BookDetail();
            bookDetail.book = book;
            bookDetail.Add = false;
            bookDetail.LoadData();
            bookDetail.NotifyEvent +=new NotifyLoadData(BookDetail_NotifyEvent);
            bookDetail.Show();
        }

        private void BookGridView_Click(object sender, EventArgs e)
        {
            
            book.ISBNBook = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
            book.BookName = BookGridView.SelectedRows[0].Cells[1].Value.ToString();
            book.PublisherName = BookGridView.SelectedRows[0].Cells[2].Value.ToString();
            book.Unit = BookGridView.SelectedRows[0].Cells[3].Value.ToString();
            book.Price = (int)BookGridView.SelectedRows[0].Cells[4].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string isbn = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
                BookDAL bookDAL = new BookDAL();
                bookDAL.DeleteBook(isbn);
            }
            LoadAllData();
        }
        /* Button "Nhập từ Excel"
         * Nhấn vào mở ra openFileDialog
         * Chọn File Excel cần nhập, ở đây là BookDatabase.xlsx
         * Xem tương ứng các trường trong lớp Book, vị trí các ô trong file Excel
         * Thay dong cuối dạng như dataGridView1.DataSource = list; bằng lệnh lưu xuống Database trong BookDAL
         * Load lại Database trên GridView         
         */

    }
}
