using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer.cs.DTO;
using System.Configuration;

namespace DataAccessLayer.cs.DAL
{
    public class ImportExportDAL
    {
        public bool CreateIE(ImportExport ie)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Insert into ImportExport values (@CheckNo, @Date, @Type, @ImportExport, @CustomerID)", con);
                cmd.Parameters.AddWithValue("CheckNo", ie.CheckNo);
                cmd.Parameters.AddWithValue("Date", ie.Date);
                cmd.Parameters.AddWithValue("Type", ie.Type);
                cmd.Parameters.AddWithValue("ImportExport", ie.ImEx);
                cmd.Parameters.AddWithValue("CustomerID", ie.CustomerName);
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
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from ImportExport where CheckNo = @No", con);
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
        public bool UpdateIE(ImportExport ie)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Update ImportExport set Date = @Date, Type = @Type, ImportExport = @ImportExport, CustomerID = @CustomerID where CheckNo = @No", con);
                cmd.Parameters.AddWithValue("Date", ie.Date);
                cmd.Parameters.AddWithValue("Type", ie.Type);
                cmd.Parameters.AddWithValue("ImportExport", ie.ImEx);
                cmd.Parameters.AddWithValue("CustomerID", ie.CustomerName);
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
        public ImportExport GetIEbyCheckNo(int No)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from ImportExport where CheckNo = @No", con);
            cmd.Parameters.AddWithValue("No", No);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            ImportExport ie = new ImportExport();
            if (sdr.HasRows)
            {
                sdr.Read();
                ie.CheckNo = (int)sdr["CheckNo"];
                ie.Date = (DateTime)sdr["Date"];
                ie.ImEx = (string)sdr["ImportExport"];
                ie.Type = (string)sdr["Type"];
                ie.CustomerName = (string)sdr["CustomerID"];
                return ie;
            }
            con.Close();
            return null;
        }
        public List<ImportExport> GetAllIE()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from ImportExport", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ImportExport> list = new List<ImportExport>();
            while (sdr.Read())
            {
                ImportExport ie = new ImportExport();

                ie.CheckNo = (int)sdr["CheckNo"];
                ie.Date = (DateTime)sdr["Date"];
                ie.ImEx = (string)sdr["ImportExport"];
                ie.Type = (string)sdr["Type"];
                ie.CustomerName = (string)sdr["CustomerName"];
                list.Add(ie);
            }
            con.Close();
            return list;
        }
    }
}
