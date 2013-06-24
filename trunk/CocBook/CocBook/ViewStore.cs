using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.DAL;
using DataAccessLayer.cs.DTO;

namespace CocBook
{
    public partial class ViewStore : Form
    {
        public ViewStore()
        {
            InitializeComponent();
            LoadAllData();
        }
        private void LoadAllData()
        {
            BookStoreDAL bookstoreDAL = new BookStoreDAL();
            List<Store> list = bookstoreDAL.GetAllStore();
            dataGridView1.DataSource = list;

        }

        private void btnSearch_Click(object sender, EventArgs e)
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
                        dataGridView1.DataSource = list;
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả. Vui lòng nhập chính xác ISBN !");
                    }
                }
                // Search By Name
                if (rdName.Checked)
                {
                    BookStoreDAL bookstoreDAL = new BookStoreDAL();
                    if (bookstoreDAL.GetBookStorebyName(search) != null)
                    {
                        List<Store> list = bookstoreDAL.GetBookStorebyName(search);
                        dataGridView1.DataSource = list;
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả. Vui lòng nhập chính xác tên sách !");
                    }
                }
                // Search by Publisher
                if (rdPulisher.Checked)
                {
                    BookStoreDAL bookstoreDAL = new BookStoreDAL();
                    if (bookstoreDAL.GetBookStorebyPublisher(search) != null)
                    {
                        List<Store> list = bookstoreDAL.GetBookStorebyPublisher(search);
                        dataGridView1.DataSource = list;
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả. Vui lòng nhập chính xác nhà xuất bản !");
                    }
                }
                // Search by Price. Need edit price from to
                if (rdPrice.Checked)
                {
                    int price = int.Parse(search);
                    BookStoreDAL bookstoreDAL = new BookStoreDAL();
                    if (bookstoreDAL.GetBookStorebyPrice(price) != null)
                    {
                        List<Store> list = bookstoreDAL.GetBookStorebyPrice(price);
                        dataGridView1.DataSource = list;
                        dataGridView1.Refresh();
                    }
                    
                }
                if(rdISBN.Checked==false && rdName.Checked==false && rdPrice.Checked==false && rdPulisher.Checked == false){
                    MessageBox.Show("Hãy chọn mục tìm kiếm !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm !");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadAllData();
            dataGridView1.Refresh();
        }
    }
}
