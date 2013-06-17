using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DTO;
using System.Data.SqlClient;


namespace DataAccessLayer.DAL
{
    class BookDAL
    {
        public bool CreateBook(Book book)
        {
            try 
    {	        
           string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Insert into Book values (@ISBN, @Name, @PublisherID, @Unit,@Price)",con);
            cmd.Parameters.AddWithValue("ISBN", book.ISBNBook);
            cmd.Parameters.AddWithValue("Name", book.BookName);
            cmd.Parameters.AddWithValue("PublisherID", book.PublisherID);
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
        public bool DeleteBookByISBN(int ISBN)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from Book where ISBNBook = @ISBN", con);
                cmd.Parameters.AddWithValue("ISBN", ISBN);
                con.Open();
                int count = cmd.ExecuteNonQuery();  // Trả về số dòng bị tác động
                con.Close();
                return (count == 1);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public Book GetProductbyISBN(int ISBN)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Book where ISBNBook = @ISBN", con);
            cmd.Parameters.AddWithValue("ISBN", ISBN);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Book book = new Book();
            if (sdr.HasRows)
            {
                sdr.Read();
                book.ISBNBook = (int)sdr["ProductID"];
                book.BookName = (string)sdr["ProductName"];
                book.PublisherID = (int)sdr["ProductName"];
                book.Unit = (string)sdr["ProductName"];
                book.Price = (int)sdr["Price"];
            }
            con.Close();
            return book;
        }
        public List<Book> GetAllProduct()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Book", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Book> list = new List<Book>();
            if (sdr.HasRows)
            {
                sdr.Read();

                Book book = new Book();
                book.ISBNBook = (int)sdr["ProductID"];
                book.BookName = (string)sdr["ProductName"];
                book.PublisherID = (int)sdr["ProductName"];
                book.Unit = (string)sdr["ProductName"];
                book.Price = (int)sdr["Price"];
                list.Add(book);
            }
            con.Close();
            return list;
        }

        
        
    }
}
