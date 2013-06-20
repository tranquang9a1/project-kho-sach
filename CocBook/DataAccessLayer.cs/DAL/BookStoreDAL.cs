using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs.DTO;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer.cs.DAL;

namespace DataAccessLayer.DAL
{
    public class BookStoreDAL
    {
        public bool CreateBookStore(BookStore bookstore)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Insert into BookStore values (@ISBN, @Quantity)", con);

                cmd.Parameters.AddWithValue("ISBN", bookstore.ISBN);
                cmd.Parameters.AddWithValue("Quantity", bookstore.Quantity);
                

                con.Open();
                int count = cmd.ExecuteNonQuery();
                con.Close();
                return (count == 1);
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool DeleteBookStore(int ISBN)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from BookStore where ISBN = @ISBN", con);
                cmd.Parameters.AddWithValue("ISBN", ISBN);
                con.Open();
                int count = cmd.ExecuteNonQuery();
                con.Close();
                return (count == 1);

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateBookStore(BookStore bookstore)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Update BookStore set Quantity = @Quantity where ISBN = @ISBN", con);
                cmd.Parameters.AddWithValue("Quantity", bookstore.Quantity);
                cmd.Parameters.AddWithValue("ISBN", bookstore.ISBN);
               

                con.Open();
                int count = cmd.ExecuteNonQuery();
                con.Close();
                return (count == 1);

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Store GetBookStorebyISBN(string ISBNBookStore)
        {

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
           
            SqlCommand cmd = new SqlCommand("Select * from BookStore where ISBN = @ISBN", con);
            cmd.Parameters.AddWithValue("ISBN", ISBNBookStore);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Store store = new Store();

            if (sdr.HasRows)
            {
                sdr.Read();
                store.ISBNBook = sdr["ISBN"].ToString();
                string ISBN = store.ISBNBook;
                store.Quantity = (int)sdr["Quantity"];
                BookDAL bookDAL = new BookDAL();
                Book book = new Book();
                book = bookDAL.GetBookbyISBN(ISBN);
                store.BookName = book.BookName;
                store.Publisher = book.PublisherName;
                store.Unit = book.Unit;
                store.Price = book.Price;
                return store;
            }
            con.Close();
            return null;
        }
        public List<Store> GetAllStore()
        {
            /*
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            */
            
            SqlConnection con = new SqlConnection(@"Server=(local);Database=CocBook;uid=sa;pwd=123456789");
            SqlCommand cmd = new SqlCommand("Select * from BookStore", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Store> list = new List<Store>();
            while (sdr.Read())
            {
                Store store = new Store();
                store.ISBNBook = sdr["ISBN"].ToString();
                string ISBN = store.ISBNBook;
                store.Quantity = (int)sdr["Quantity"];
                Book book = new Book();
                BookDAL bookDAL = new BookDAL();
                book = bookDAL.GetBookbyISBN(ISBN);
                store.BookName = book.BookName;
                store.Publisher = book.PublisherName;
                store.Unit = book.Unit;
                store.Price = book.Price;
                list.Add(store);
            }
            con.Close();
            return list;

        }
        public List<Store> GetBookStorebyName(string name)
        {
            List<Store> list = new List<Store>();
            List<Book> listBook = new List<Book>();
            BookDAL bookDAL = new BookDAL();
            listBook = bookDAL.GetBookbyName(name);
            foreach (var book in listBook)
            {
                Store store = new Store();
                store.ISBNBook = book.ISBNBook;
                store.BookName = book.BookName;
                store.Publisher = book.PublisherName;
                store.Unit = book.Unit;
                store.Price = book.Price;
                string ISBN = book.ISBNBook;
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
           
                SqlCommand cmd = new SqlCommand("Select * from BookStore where ISBN = @ISBN", con);
                cmd.Parameters.AddWithValue("ISBN", ISBN);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    store.Quantity = (int)sdr["Quantity"];
                }
                con.Close();
                list.Add(store);
            }
            return list;
        }
        public List<Store> GetBookStorebyPublisher(string publisher)
        {
            List<Store> list = new List<Store>();
            List<Book> listBook = new List<Book>();
            BookDAL bookDAL = new BookDAL();
            listBook = bookDAL.GetBookbyPublisherName(publisher);
            foreach (var book in listBook)
            {
                Store store = new Store();
                store.ISBNBook = book.ISBNBook;
                store.BookName = book.BookName;
                store.Publisher = book.PublisherName;
                store.Unit = book.Unit;
                store.Price = book.Price;
                string ISBN = book.ISBNBook;
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("Select * from BookStore where ISBN = @ISBN", con);
                cmd.Parameters.AddWithValue("ISBN", ISBN);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    store.Quantity = (int)sdr["Quantity"];
                }
                con.Close();
                list.Add(store);
            }
            return list;
        }
        public List<Store> GetBookStorebyPrice(int price)
        {
            List<Store> list = new List<Store>();
            List<Book> listBook = new List<Book>();
            BookDAL bookDAL = new BookDAL();
            listBook = bookDAL.GetBookbyPrice(price);
            foreach (var book in listBook)
            {
                Store store = new Store();
                store.ISBNBook = book.ISBNBook;
                store.BookName = book.BookName;
                store.Publisher = book.PublisherName;
                store.Unit = book.Unit;
                store.Price = book.Price;
                string ISBN = book.ISBNBook;
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("Select * from BookStore where ISBN = @ISBN", con);
                cmd.Parameters.AddWithValue("ISBN", ISBN);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    store.Quantity = (int)sdr["Quantity"];
                }
                con.Close();
                list.Add(store);
            }
            return list;
        }
    }
}
