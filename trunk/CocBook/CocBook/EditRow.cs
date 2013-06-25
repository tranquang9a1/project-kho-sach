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
    public delegate void ImportRow();
    public partial class EditRow : Form
    {
        public event ImportRow importRowEvent;
        public IEDetail ieDetail = new IEDetail();
        IEDetailDAL ieDetailDAL = new IEDetailDAL();
        ChooseBook chooseBook = new ChooseBook();
        BookDAL bookDAL = new BookDAL();
        public Book book = new Book();
        public bool Add;
        public EditRow()
        {
            InitializeComponent();
        }

        private void btnChooseBook_Click(object sender, EventArgs e)
        {
            chooseBook.importEvent += new ImportEvent(chooseBook_importEvent);
            chooseBook.ShowDialog();
        }

        void chooseBook_importEvent()
        {
            ieDetail.ISBNBook = chooseBook.book.ISBNBook;
            txtBookName.Text = chooseBook.book.BookName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Add)
            {

                ieDetail.Quantity = int.Parse(txtQuantity.Text);
                ieDetail.Discount = int.Parse(txtDiscount.Text);
                book = bookDAL.GetBookbyISBN(ieDetail.ISBNBook);
                ieDetail.Value = (book.Price * ieDetail.Quantity * (100-ieDetail.Discount)) / 100;
                ieDetailDAL.CreateIEDetail(ieDetail);

            }
            else
            {

                ieDetail.ISBNBook=book.ISBNBook;
                ieDetail.Quantity=int.Parse(txtQuantity.Text);
                ieDetail.Discount=int.Parse(txtDiscount.Text);
                ieDetail.Value = (book.Price * ieDetail.Quantity * ieDetail.Discount) / 100;
                ieDetailDAL.UpdateIEDetail(ieDetail);
            }
            Close();
            if(importRowEvent!=null){
                importRowEvent();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void LoadData()
        {
            if (!Add)
            {
                txtBookName.Text = book.BookName;
                txtBookName.ReadOnly = true;
                txtDiscount.Text = ieDetail.Discount.ToString();
                txtQuantity.Text = ieDetail.Quantity.ToString();
            }
            else
            {
                txtBookName.ReadOnly = false;
            }
        }
    }
}
