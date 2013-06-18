using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs.DTO;
using System.Data.SqlClient;

namespace DataAccessLayer.cs.DAL
{
    public class BookDAL
    {
         public bool CreateBook(Book book)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Insert into Book values (@ISBN, @Name, @PublisherName, @Unit, @Price)", con);
                
                cmd.Parameters.AddWithValue("ISBN", book.ISBNBook);
                cmd.Parameters.AddWithValue("Name", book.BookName);
                cmd.Parameters.AddWithValue("PublisherName", book.PublisherName);
                cmd.Parameters.AddWithValue("Unit", book.Unit);
                cmd.Parameters.AddWithValue("Price", book.Price);

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
        public bool DeleteBook(int ISBNBook)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from Book where ISBNBook = @ISBN", con);
                cmd.Parameters.AddWithValue("ISBN", ISBNBook);
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
        public bool UpdateBook(Book book)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Update Book set BookName = @Name, PublisherName = @PublisherName, Unit = @Unit, Price = @Price where ISBNBook = @ISBN", con);
                cmd.Parameters.AddWithValue("Name", book.BookName);
                cmd.Parameters.AddWithValue("PublisherName", book.PublisherName);
                cmd.Parameters.AddWithValue("Unit", book.Unit);
                cmd.Parameters.AddWithValue("Price", book.Price);
                cmd.Parameters.AddWithValue("ISBN", book.ISBNBook);

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
        public Book GetBookbyISBN(int ISBNBook)
        {

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Book where ISBNBook = @ISBN", con);
            cmd.Parameters.AddWithValue("ISBN", ISBNBook);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Book book = new Book();

            if (sdr.HasRows)
            {
                sdr.Read();
                book.ISBNBook = (string)sdr["ISBNBook"];
                book.BookName = (string)sdr["BookName"];
                book.PublisherName = (string)sdr["PublisherName"];
                book.Unit = (string)sdr["Unit"];
                book.Price = (int)sdr["Price"];
                return book;
            }
            con.Close();
            return null;
        }
        public List<Book> GetAllBook()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Book", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Book> list = new List<Book>();
            while (sdr.Read())
            {
                Book book = new Book();
                book.ISBNBook = (string)sdr["ISBNBook"];
                book.BookName = (string)sdr["BookName"];
                book.PublisherName = (string)sdr["PublisherName"];
                book.Unit = (string)sdr["Unit"];
                book.Price = (int)sdr["Price"];
                list.Add(book);
            }
            con.Close();
            return list;
        
    }
    }
}
