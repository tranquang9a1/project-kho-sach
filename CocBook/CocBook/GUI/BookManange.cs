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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using DataAccessLayer.DAL;

namespace CocBook
{
    public delegate void ChooseBook();
    public partial class BookManage : Form
    {
        LogFile logger = new LogFile();
        public event ChooseBook chooseEvent;
        bool isAdd = false;
        public bool CanDeleted = true;
        public Book book = new Book();

        public BookManage(bool delete)
        {
            InitializeComponent();
            CanDeleted = delete;
            if (CanDeleted)
            {
                btnDelete.Text = "Xóa";
            }
            else
            {
                btnDelete.Text = "Chọn";
            }
            LoadAllData();
        }

        public void LoadAllData()
        {
            BookDAL BookDAL = new BookDAL();
            List<Book> list = BookDAL.GetAllBook();

            BookGridView.DataSource = list;

        }

        private void BookGridView_Click(object sender, EventArgs e)
        {
            try
            {
                txtISBN.ReadOnly = true;
                txtISBN.Text = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
                txtBookName.Text = BookGridView.SelectedRows[0].Cells[1].Value.ToString();
                txtPublisher.Text = BookGridView.SelectedRows[0].Cells[2].Value.ToString();
                txtUnit.Text = BookGridView.SelectedRows[0].Cells[3].Value.ToString();
                txtPrice.Text = BookGridView.SelectedRows[0].Cells[4].Value.ToString();

                groupBoxDetail.Enabled = true;

                book.BookName = BookGridView.SelectedRows[0].Cells[1].Value.ToString();
                book.ISBNBook = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
                book.Price = int.Parse(BookGridView.SelectedRows[0].Cells[4].Value.ToString());
                book.PublisherName = BookGridView.SelectedRows[0].Cells[2].Value.ToString();
                book.Unit = BookGridView.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CanDeleted)
            {
                try
                {

                    if (MessageBox.Show("Bạn có muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string isbn = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
                        BookDAL bookDAL = new BookDAL();
                        bookDAL.DeleteBook(isbn);
                    }
                    makeAllBlank();
                    LoadAllData();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Không thể xóa vì sách đã có trong phiếu !");
                    logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + sqlEx.Message + "'");
                }
                catch (Exception ex)
                {

                    logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
                }
            }
            else
            {
                try
                {
                    Close();
                    if (chooseEvent != null)
                    {
                        chooseEvent();
                    }
                }
                catch (Exception ex)
                {

                    logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
                }
            }
        }

        private void btnImportFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 2;
                BookDAL bookDAL = new BookDAL();

                while (xlWorkSheet.get_Range("A" + i, "A" + i).Value2 != null)
                {

                    Book book = new Book();
                    book.BookName = xlWorkSheet.get_Range("A" + i, "A" + i).Value2.ToString();
                    book.PublisherName = xlWorkSheet.get_Range("B" + i, "B" + i).Value2.ToString();
                    book.Unit = xlWorkSheet.get_Range("C" + i, "C" + i).Value2.ToString();
                    book.Price = int.Parse(xlWorkSheet.get_Range("D" + i, "D" + i).Value2.ToString());
                    book.ISBNBook = xlWorkSheet.get_Range("E" + i, "E" + i).Value2.ToString();
                    i++;
                    Book book1 = bookDAL.GetBookbyISBN(book.ISBNBook);
                    if (book1 == null)
                    {
                        bookDAL.CreateBook(book);
                    }
                    else if (book1 != book)
                    {

                        if (MessageBox.Show("Bạn có cập nhật " + book1.BookName + " - " + book1.PublisherName + " - " + book1.Price + " thành " + book.BookName + " - " + book.PublisherName + " - " + book.Price, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bookDAL.UpdateBook(book1);
                        }
                    }

                }
                MessageBox.Show("Thêm sách thành công");
                LoadAllData();



                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                SaveToDB();
            }
        }
        private bool ValidateData()
        {
            if (txtISBN.Text == "")
            {
                MessageBox.Show("Hãy nhập mã số ISBN");
                txtISBN.Focus();
                return false;
            }
            if (txtBookName.Text == "")
            {
                MessageBox.Show("Hãy nhập tên sách !");
                txtBookName.Focus();
                return false;
            }
            int price = 0;
            try
            {
                price = int.Parse(txtPrice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập giá bằng số nguyên!");
                return false;
            }
            if (price < 0)
            {
                txtPrice.Text = "";
                MessageBox.Show("Hãy nhập giá tiền bằng số dương!");
                return false;
            }

            return true;
        }
        private void SaveToDB()
        {
            Book book = new Book();
            BookDAL bookDAL = new BookDAL();
            try
            {
                book.ISBNBook = txtISBN.Text;
                book.BookName = txtBookName.Text;
                book.PublisherName = txtPublisher.Text;
                book.Unit = txtUnit.Text;
                book.Price = int.Parse(txtPrice.Text);
                bool rs;
                if (isAdd)
                {
                    rs = bookDAL.CreateBook(book);
                }
                else
                {
                    rs = bookDAL.UpdateBook(book);
                }
                if (rs)
                {
                    MessageBox.Show("Đã lưu !");
                    LoadAllData();
                    makeAllBlank();
                }
                else
                {
                    MessageBox.Show("Không thể lưu !");
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'"); ;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupBoxDetail.Enabled = true;
            makeAllBlank();
            txtISBN.ReadOnly = false;
            isAdd = true;
        }
        private void makeAllBlank()
        {
            txtISBN.ReadOnly = true;
            txtISBN.Text = "";
            txtBookName.Text = "";
            txtPrice.Text = "";
            txtPublisher.Text = "";
            txtUnit.Text = "";
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
                            BookGridView.DataSource = list;
                            BookGridView.Refresh();
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
                                BookGridView.DataSource = list;
                                BookGridView.Refresh();
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
