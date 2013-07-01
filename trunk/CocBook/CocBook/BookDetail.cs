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
    public delegate void NotifyLoadData();
    public partial class BookDetail : Form
    {

        LogFile logger = new LogFile();
        public bool Add { get; set; }
        public Book book = new Book();
        public event NotifyLoadData NotifyEvent;

        public BookDetail()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                BookDAL bookDAL = new BookDAL();

                if (Add)
                {

                    int price = 0;
                    if (txtISBN.Text == "")
                    {
                        MessageBox.Show("Hãy nhập mã số ISBN");
                        txtISBN.Focus();
                    }
                    else
                    {
                        book.ISBNBook = txtISBN.Text;
                    }

                    if (txtBookName.Text == "")
                    {
                        MessageBox.Show("Hãy nhập tên sách !");
                        txtBookName.Focus();
                    }


                    else
                    {
                        book.BookName = txtBookName.Text;
                        book.PublisherName = txtPulisher.Text;
                        book.Unit = txtUnit.Text;

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
                            book.Price = price;
                            bookDAL.CreateBook(book);
                        }
                        else
                        {
                            MessageBox.Show("Hãy nhập giá tiền bằng số !");
                        }
                    }
                }
                else
                {
                    txtISBN.ReadOnly = true;
                    book.BookName = txtBookName.Text;
                    book.PublisherName = txtPulisher.Text;
                    book.Unit = txtUnit.Text;
                    book.Price = int.Parse(txtPrice.Text);
                    bookDAL.UpdateBook(book);
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
                    txtISBN.ReadOnly = true;
                    txtISBN.Text = book.ISBNBook;
                    txtBookName.Text = book.BookName;
                    txtPulisher.Text = book.PublisherName;
                    txtUnit.Text = book.Unit;
                    txtPrice.Text = book.Price.ToString();
                }
                else
                {
                    txtISBN.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
