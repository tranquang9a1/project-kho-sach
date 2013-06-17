using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer.cs.DTO;
using System.Configuration;

namespace DataAccessLayer.cs.DAL
{
    class IEDAL
    {
        public bool CreateIE(IE ie)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Insert into Import/Export values (@No, @Date, @Type, @IE, @CustomerID)", con);
                cmd.Parameters.AddWithValue("No", ie.CheckNo);
                cmd.Parameters.AddWithValue("Date", ie.Date);
                cmd.Parameters.AddWithValue("Type", ie.Type);
                cmd.Parameters.AddWithValue("IE", ie.IE);
                cmd.Parameters.AddWithValue("CustomerID", ie.CustomerID);
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
        public bool DeleteIE(int No)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from Import/Export where CheckNo = @No", con);
                cmd.Parameters.AddWithValue("No", No);
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
        public bool UpdateIE(IE ie)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Update Import/Export set Date = @Date, Type = @Type, [Import/Export] = @IE, CustomerID = @ID where CheckNo = @No", con);
                cmd.Parameters.AddWithValue("Date", ie.Date);
                cmd.Parameters.AddWithValue("Type", ie.Type);
                cmd.Parameters.AddWithValue("IE", ie.IE);
                cmd.Parameters.AddWithValue("ID", ie.CustomerID);
                cmd.Parameters.AddWithValue("No", ie.CheckNo);
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
        public IE GetIEbyCheckNo(int No)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Import/Export where CheckNo = @No", con);
            cmd.Parameters.AddWithValue("No", No);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            IE ie = new IE();
            if (sdr.HasRows)
            {
                sdr.Read();
                ie.CheckNo = (int)sdr["CheckNo"];
                ie.Date = (DateTime)sdr["Date"];
                ie.IE = (string)sdr["IE"];
                ie.Type = (string)sdr["Type"];
                ie.CustomerID = (string)sdr["CustomerID"];
                return ie;
            }
            con.Close();
            return null;
        }
        public List<IE> GetAllIE()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Import/Export", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<IE> list = new List<IE>();
            while (sdr.Read())
            {
                IE ie = new IE();

                ie.CheckNo = (int)sdr["CheckNo"];
                ie.Date = (DateTime)sdr["Date"];
                ie.IE = (string)sdr["IE"];
                ie.Type = (string)sdr["Type"];
                ie.CustomerID = (string)sdr["CustomerID"];
                list.Add(ie);
            }
            con.Close();
            return list;
        }
    }
}
