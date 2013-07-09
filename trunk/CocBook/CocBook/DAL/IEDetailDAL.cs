using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer.cs.DTO;
using System.Configuration;

namespace DataAccessLayer.cs.DAL
{
    public class IEDetailDAL
    {
        public bool CreateIEDetail(IEDetail iedetail)
        {
            try
            {
                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);


                //Insert Command
                SqlCommand cmd = new SqlCommand("Insert into IEDetail values (@CheckNo,@ISBNBook,@Quantity,@Discount,@Value)", con);
                cmd.Parameters.AddWithValue("CheckNo", iedetail.CheckNo);
                cmd.Parameters.AddWithValue("ISBNBook", iedetail.ISBNBook);
                cmd.Parameters.AddWithValue("Quantity", iedetail.Quantity);
                cmd.Parameters.AddWithValue("Discount", iedetail.Discount);
                cmd.Parameters.AddWithValue("Value", iedetail.Value);
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
        public bool UpdateIEDetail(IEDetail iedetail)
        {

            try
            {
                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);
                //
                //Update Command
                SqlCommand cmd = new SqlCommand("UPDATE IEDetail SET Quantity = @quantity, Discount = @discount, Value = @value WHERE CheckNo = @no AND ISBNBook = @isbn", con);
                cmd.Parameters.AddWithValue("quantity", iedetail.Quantity);
                cmd.Parameters.AddWithValue("discount", iedetail.Discount);
                cmd.Parameters.AddWithValue("value", iedetail.Value);
                cmd.Parameters.AddWithValue("no", iedetail.CheckNo);
                cmd.Parameters.AddWithValue("isbn", iedetail.ISBNBook);
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
        public bool DeleteOrderByCheckNoAndISBN(int no, string ISBN)
        {
            try
            {

                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);

                // SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
                //

                //Delete Command
                SqlCommand cmd = new SqlCommand("DELETE from IEDetail WHERE CheckNo = @no AND ISBNBook = @isbn", con);
                cmd.Parameters.AddWithValue("no", no);
                cmd.Parameters.AddWithValue("isbn", ISBN);
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
        public List<IEDetail> GetAllIEDetail()
        {

            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);

            //SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            // View all Command
            SqlCommand cmd = new SqlCommand("SELECT * from IEDetail", con);
            //
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            List<IEDetail> list = new List<IEDetail>();

            while (sdr.Read())
            {

                IEDetail iedetail = new IEDetail();
                iedetail.CheckNo = (int)sdr["CheckNo"];
                iedetail.ISBNBook = (string)sdr["ISBNBook"];
                iedetail.Quantity = (int)sdr["Quantity"];
                iedetail.Discount = (int)sdr["Discount"];
                iedetail.Value = (int)sdr["Value"];
                list.Add(iedetail);
            }
            con.Close();
            return list;
        }
        public List<IEDetail> GetIEDetailByCheckNo(int no)
        {


            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);

            //SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            // View all Command
            SqlCommand cmd = new SqlCommand("SELECT * FROM IEDetail WHERE CheckNo = @cNo", con);
            cmd.Parameters.AddWithValue("cNo", no);
            //
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            List<IEDetail> list = new List<IEDetail>();

            while (sdr.Read())
            {

                IEDetail iedetail = new IEDetail();
                iedetail.CheckNo = (int)sdr["CheckNo"];
                iedetail.ISBNBook = (string)sdr["ISBNBook"];
                iedetail.Quantity = (int)sdr["Quantity"];
                iedetail.Discount = (int)sdr["Discount"];
                iedetail.Value = (int)sdr["Value"];
                list.Add(iedetail);
            }
            con.Close();
            return list;
        }
        public List<IEDetail> GetIEDetailByISBN(string isbn)
        {


            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);

            //SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            // View all Command
            SqlCommand cmd = new SqlCommand("SELECT * FROM IEDetail WHERE ISBNBook = @isbn", con);
            cmd.Parameters.AddWithValue("isbn", isbn);
            //
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            List<IEDetail> list = new List<IEDetail>();

            while (sdr.Read())
            {

                IEDetail iedetail = new IEDetail();
                iedetail.CheckNo = (int)sdr["CheckNo"];
                iedetail.ISBNBook = (string)sdr["ISBNBook"];
                iedetail.Quantity = (int)sdr["Quantity"];
                iedetail.Discount = (int)sdr["Discount"];
                iedetail.Value = (int)sdr["Value"];
                list.Add(iedetail);
            }
            con.Close();
            return list;
        }
        public IEDetail GetIEDetailByCheckNoAndISBN(int no, string isbn)
        {
            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);

            //SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            SqlCommand cmd = new SqlCommand("SELECT * FROM IEDetail WHERE CheckNo = @no AND ISBNBook = @isbn", con);
            cmd.Parameters.AddWithValue("no", no);
            cmd.Parameters.AddWithValue("isbn", isbn);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            IEDetail iedetail = new IEDetail();
            if (sdr.HasRows)
            {
                sdr.Read();
                iedetail.CheckNo = (int)sdr["CheckNo"];
                iedetail.ISBNBook = (string)sdr["ISBNBook"];
                iedetail.Quantity = (int)sdr["Quantity"];
                iedetail.Discount = (int)sdr["Discount"];
                iedetail.Value = (int)sdr["Value"];
                return iedetail;
            }
            con.Close();
            return null;
        }
        public bool HasIEWithCheckNo(int no)
        {
            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);

            //SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            SqlCommand cmd = new SqlCommand("SELECT * FROM IEDetail WHERE CheckNo = @no", con);
            cmd.Parameters.AddWithValue("no", no);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                return true;
            }
            con.Close();
            return false;
        }
    }
}
