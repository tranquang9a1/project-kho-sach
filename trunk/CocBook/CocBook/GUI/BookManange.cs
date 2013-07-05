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

namespace CocBook
{
    public partial class BookManage : Form
    {
        LogFile logger = new LogFile();
        bool isAdd = false;

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
                if (MessageBox.Show("Bạn có muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string isbn = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
                    BookDAL bookDAL = new BookDAL();
                    bookDAL.DeleteBook(isbn);
                }
                makeAllBlank();
                LoadAllData();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
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
            Book book1 = new Book();
            int price = 0;
            if (txtISBN.Text == "")
            {
                MessageBox.Show("Hãy nhập mã số ISBN");
                txtISBN.Focus();
            }
            else
            {
                book1.ISBNBook = txtISBN.Text;
            }

            if (txtBookName.Text == "")
            {
                MessageBox.Show("Hãy nhập tên sách !");
                txtBookName.Focus();
            }


            else
            {
                book1.BookName = txtBookName.Text;
                book1.PublisherName = txtPublisher.Text;
                book1.Unit = txtUnit.Text;

                try
                {
                    price = int.Parse(txtPrice.Text);
                }
                catch (Exception)
                {
                    txtPrice.Text = "";
                }
                if (price < 0)
                {
                    txtPrice.Text = "";
                    MessageBox.Show("Hãy nhập giá tiền bằng số dương!");
                }
                else if (price > 0)
                {
                    book1.Price = price;
                    BookDAL bookDAL = new BookDAL();
                    bool rs;
                    if (isAdd)
                    {
                        rs = bookDAL.CreateBook(book1);
                    }
                    else
                    {
                        rs = bookDAL.UpdateBook(book1);
                    }
                    if (rs)
                    {
                        MessageBox.Show("Đã lưu !");
                        LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu !");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập giá tiền bằng số !");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makeAllBlank();
        }
        private void makeAllBlank()
        {
            txtISBN.ReadOnly = false;
            txtISBN.Text = "";
            txtBookName.Text = "";
            txtPrice.Text = "";
            txtPublisher.Text = "";
            txtUnit.Text = "";
            isAdd = true;
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
