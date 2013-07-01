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

        private void BookGridView_Click(object sender, EventArgs e)
        {
            try
            {
                book.ISBNBook = BookGridView.SelectedRows[0].Cells[0].Value.ToString();
                book.BookName = BookGridView.SelectedRows[0].Cells[1].Value.ToString();
                book.PublisherName = BookGridView.SelectedRows[0].Cells[2].Value.ToString();
                book.Unit = BookGridView.SelectedRows[0].Cells[3].Value.ToString();
                book.Price = (int)BookGridView.SelectedRows[0].Cells[4].Value;
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
        }

    }
