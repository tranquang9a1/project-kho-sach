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
    
    public partial class EditRow : Form
    {
        public IEDetail ieDetail = new IEDetail();
        IEDetailDAL ieDetailDAL = new IEDetailDAL();
        ChooseBook chooseBook = new ChooseBook();
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
            BookDAL bookDAL = new BookDAL();
            Book book = new Book();
            ieDetail.Quantity = int.Parse(txtQuantity.Text);
            ieDetail.Discount = int.Parse(txtDiscount.Text);
            book = bookDAL.GetBookbyISBN(ieDetail.ISBNBook);
            ieDetail.Value = (book.Price * ieDetail.Quantity * ieDetail.Discount) / 100;
            ieDetailDAL.CreateIEDetail(ieDetail);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
