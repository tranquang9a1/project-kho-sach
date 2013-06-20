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
    public delegate void TotalCost();
    public partial class EditRow : Form
    {
        public IEDetail ieDetail = new IEDetail();
        IEDetailDAL ieDetailDAL = new IEDetailDAL();
        ChooseBook chooseBook = new ChooseBook();
        BookDAL bookDAL = new BookDAL();
        Book book = new Book();
        public event TotalCost totalCost;
        public bool Add;
        public EditRow()
        {
            InitializeComponent();
        }

        private void btnChooseBook_Click(object sender, EventArgs e)
        {
            
            chooseBook.ShowDialog();
            chooseBook.importEvent += new ImportEvent(chooseBook_importEvent);

            
        }

        void chooseBook_importEvent()
        {
            ieDetail.ISBNBook = chooseBook.book.ISBNBook;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Add)
            {
                
                ieDetail.Quantity = int.Parse(txtQuantity.Text);
                ieDetail.Discount = int.Parse(txtDiscount.Text);
                book = bookDAL.GetBookbyISBN(ieDetail.ISBNBook);
                ieDetail.Value = (book.Price * ieDetail.Quantity * ieDetail.Discount) / 100;
                ieDetailDAL.CreateIEDetail(ieDetail);

            }
            else
            {
                
                txtISBNBook.Text = ieDetail.ISBNBook;
                txtQuantity.Text = ieDetail.Quantity.ToString();
                txtDiscount.Text = ieDetail.Discount.ToString();
                book = bookDAL.GetBookbyISBN(ieDetail.ISBNBook);
                ieDetail.Value = (book.Price * ieDetail.Quantity * ieDetail.Discount) / 100;
                ieDetailDAL.UpdateIEDetail(ieDetail);
            }

            if (totalCost != null)
            {
                totalCost();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
