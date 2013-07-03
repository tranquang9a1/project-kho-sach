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
    public delegate void ImportEvent();
    public partial class ChooseBook : Form
    {
        LogFile logger = new LogFile();
        public event ImportEvent importEvent;
        public Book book = new Book();
        public ChooseBook()
        {
            InitializeComponent();
            LoadAllData();
        }
        public void LoadAllData()
        {
            BookDAL BookDAL = new BookDAL();
            List<Book> list = BookDAL.GetAllBook();

            BookGridView1.DataSource = list;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BookDetail bookDetail = new BookDetail();
                bookDetail.Add = true;
                bookDetail.NotifyEvent += new NotifyLoadData(BookDetail_NotifyEvent);
                bookDetail.Show();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }


            
        }
        void BookDetail_NotifyEvent()
        {
            LoadAllData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                BookDetail bookDetail = new BookDetail();
                bookDetail.book = book;
                bookDetail.Add = false;
                bookDetail.LoadData();
                bookDetail.NotifyEvent += new NotifyLoadData(BookDetail_NotifyEvent);
                bookDetail.Show();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        private void BookGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                book.ISBNBook = BookGridView1.SelectedRows[0].Cells[0].Value.ToString();
                book.BookName = BookGridView1.SelectedRows[0].Cells[1].Value.ToString();
                book.PublisherName = BookGridView1.SelectedRows[0].Cells[2].Value.ToString();
                book.Unit = BookGridView1.SelectedRows[0].Cells[3].Value.ToString();
                book.Price = (int)BookGridView1.SelectedRows[0].Cells[4].Value;
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
                Close();
                if (importEvent != null)
                {
                    importEvent();
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }


            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    string search = txtSearch.Text;
                    // Search by ISBN
                    if (rdISBN.Checked)
                    {
                        Store store = new Store();
                        BookStoreDAL bookstoreDAL = new BookStoreDAL();
                        if (bookstoreDAL.GetBookStorebyISBN(search) != null)
                        {
                            store = bookstoreDAL.GetBookStorebyISBN(search);
                            List<Store> list = new List<Store>();
                            list.Add(store);
                            BookGridView1.DataSource = list;
                            BookGridView1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy kết quả. Vui lòng nhập chính xác ISBN!");
                        }
                    }
                    else
                    {
                        // search by BookName
                        if (rdBookName.Checked)
                        {
                            BookStoreDAL bookstoreDAL = new BookStoreDAL();
                            if (bookstoreDAL.GetBookStorebyName(search) != null)
                            {
                                List<Store> list = bookstoreDAL.GetBookStorebyName(search);
                                BookGridView1.DataSource = list;
                                BookGridView1.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy kết quả. Vui lòng nhập chính xác tên sách!");
                            }
                        }
                        if (rdISBN.Checked == false && rdBookName.Checked == false)
                        {
                            MessageBox.Show("Hãy chọn mục tìm kiếm !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập giá trị tìm kiếm !");
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }

        }
    }
}
