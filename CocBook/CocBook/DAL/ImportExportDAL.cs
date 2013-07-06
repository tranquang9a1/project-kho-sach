using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer.cs.DTO;
using System.Configuration;
using CocBook.DTO;

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

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Delete from ImportExport where CheckNo = @No", con);
            cmd.Parameters.AddWithValue("No", No);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return (count == 1);
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
                cmd.Parameters.AddWithValue("CustomerID", ie.CustomerID);
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
                ie.CustomerID = (int)sdr["CustomerID"];
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
                ie.CustomerID = (int)sdr["CustomerID"];
                list.Add(ie);
            }
            con.Close();
            return list;
        }
        public List<OpenImportExport> GetAllOpenIE(List<ImportExport> listIE)
        {
            List<OpenImportExport> result = new List<OpenImportExport>();
            listIE = GetAllIE();
            foreach (var item in listIE)
            {
                OpenImportExport openIE = new OpenImportExport();
                CustomerDAL customerDAL = new CustomerDAL();
                openIE.CheckNo = item.CheckNo;
                openIE.Date = item.Date;
                openIE.Type = item.Type;
                openIE.ImEx = item.ImEx;
                openIE.CustomerName = customerDAL.GetCustomerbyID(item.CustomerID).CustomerName;
                result.Add(openIE);
            }
            return result;
        }
        public List<OpenImportExport> GetImport()
        {
            List<OpenImportExport> list = new List<OpenImportExport>();
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from ImportExport where ImportExport = @I", con);
            cmd.Parameters.AddWithValue("I", "Nhập");
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                OpenImportExport openIE = new OpenImportExport();
                CustomerDAL customerDAL = new CustomerDAL();
                openIE.CheckNo = (int)sdr["CheckNo"];
                openIE.Date = (DateTime)sdr["Date"];
                openIE.Type = (string)sdr["Type"];
                openIE.ImEx = (string)sdr["ImportExport"];
                int customerID = (int)sdr["CustomerID"];
                openIE.CustomerName = customerDAL.GetCustomerbyID(customerID).CustomerName;
                list.Add(openIE);
            }
            con.Close();
            return list;
        }
        public List<OpenImportExport> GetExport()
        {
            List<OpenImportExport> list = new List<OpenImportExport>();
            ImportExportDAL IEDAL = new ImportExportDAL();
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from ImportExport where ImportExport = @E", con);
            cmd.Parameters.AddWithValue("E", "Xuất");
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                OpenImportExport openIE = new OpenImportExport();
                CustomerDAL customerDAL = new CustomerDAL();
                openIE.CheckNo = (int)sdr["CheckNo"];
                openIE.Date = (DateTime)sdr["Date"];
                openIE.Type = (string)sdr["Type"];
                openIE.ImEx = (string)sdr["ImportExport"];
                int customerID = (int)sdr["CustomerID"];
                openIE.CustomerName = customerDAL.GetCustomerbyID(customerID).CustomerName;
                list.Add(openIE);
            }
            con.Close();
            return list;
        }
    }
}
