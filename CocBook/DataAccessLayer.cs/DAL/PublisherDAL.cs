using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs.DTO;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.cs.DAL
{
    public class PublisherDAL
    {
        public bool CreatePulisher(Publisher publisher)
        {
            try
            {
                // ConnectionString to DB
                /*ConnectionString Error
                string cs = ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                */
                SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
                //

                //Insert Command
                SqlCommand cmd = new SqlCommand("INSERT INTO Publisher(PulisherName) VALUES (@Name)", con);
                cmd.Parameters.AddWithValue("Name", publisher.PublisherName);
                //
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
        public bool UpdatePublisher(Publisher publisher)
        {

            try
            {
                // ConnectionString to DB
                /*ConnectionString Error
                string cs = ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                */
                SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
                //
                //Update Command
                SqlCommand cmd = new SqlCommand("UPDATE Publisher SET PublisherName = @name WHERE PublisherID = @id", con);
                cmd.Parameters.AddWithValue("name", publisher.PublisherName);
                cmd.Parameters.AddWithValue("id", publisher.PublisherID);
                //
                con.Open();
                int count = cmd.ExecuteNonQuery();  // Trả về số dòng bị tác động
                con.Close();
                return (count == 1);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeletePublisherByID(int id)
        {
            try
            {
                // ConnectionString to DB
                /*ConnectionString Error
                string cs = ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                */
                SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
                //

                //Delete Command
                SqlCommand cmd = new SqlCommand("Delete from Publisher where PublisherID = @id", con);
                cmd.Parameters.AddWithValue("id", id);
                //
                con.Open();
                int count = cmd.ExecuteNonQuery();
                con.Close();
                return (count == 1);
            }
            catch (Exception)
            {

                return false; ;
            }
        }
        public List<Publisher> GetAllPublisher()
        {
            // ConnectionString to DB
            /*ConnectionString Error
            string cs = ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            */
            SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            // View all Command
            SqlCommand cmd = new SqlCommand("Select * from Publisher", con);
            //
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            List<Publisher> list = new List<Publisher>();

            while (sdr.Read())
            {

                Publisher publisher = new Publisher();
                publisher.PublisherID = (int)sdr["PublisherID"];
                publisher.PublisherName = (string)sdr["PublisherName"];
                list.Add(publisher);
            }
            con.Close();
            return list;
        }
        public Publisher GetPublisherById(int id)
        {

            // ConnectionString to DB
            /*ConnectionString Error
            string cs = ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            */
            SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            SqlCommand cmd = new SqlCommand("Select * from Publisher where PublisherId = @id", con);
            cmd.Parameters.AddWithValue("id", id);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Publisher publisher = new Publisher();
            if (sdr.HasRows)
            {
                sdr.Read();


                publisher.PublisherID = (int)sdr["PublisherID"];
                publisher.PublisherName = (string)sdr["PublisherName"];
            }
            con.Close();
            return publisher;
        }
    }
}
