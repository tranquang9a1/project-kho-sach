using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs.DTO;
using System.Data.SqlClient;

namespace DataAccessLayer.cs.DAL
{
    public class BookStoreDALcs
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
        public BookStore GetBookStorebyISBN(int ISBNBookStore)
        {

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from BookStore where ISBN = @ISBN", con);
            cmd.Parameters.AddWithValue("ISBN", ISBNBookStore);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            BookStore bookstore = new BookStore();

            if (sdr.HasRows)
            {
                sdr.Read();
                bookstore.ISBN = (int)sdr["ISBN"];
                bookstore.Quantity = (int)sdr["Quantity"];
                
                return bookstore;
            }
            con.Close();
            return null;
        }
        public List<BookStore> GetAllBookStore()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from BookStore", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<BookStore> list = new List<BookStore>();
            while (sdr.Read())
            {
                BookStore bookstore = new BookStore();
                bookstore.ISBN = (int)sdr["ISBN"];
                bookstore.Quantity = (int)sdr["Quantity"];
                
                list.Add(bookstore);
            }
            con.Close();
            return list;

        }
    }
}
