using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs.DTO;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer.cs.DAL
{
    public class CustomerDAL
    {
        public bool CreateCustomer(Customer customer)
        {
            try
            {
                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer (CustomerName,Address,Phone,TaxNo) VALUES (@CustomerName, @Address, @Phone, @TaxNo)", con);
                cmd.Parameters.AddWithValue("CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("Address", customer.Address);
                cmd.Parameters.AddWithValue("Phone", customer.Phone);
                cmd.Parameters.AddWithValue("TaxNo", customer.TaxNo);
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
        public bool DeleteCustomer(int CustomerID)
        {
           
                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from Customer where CustomerID = @CustomerID", con);
                cmd.Parameters.AddWithValue("CustomerID", CustomerID);
                con.Open();
                int count = cmd.ExecuteNonQuery();
                con.Close();
                return (count == 1);

            
        }
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("UPDATE Customer SET CustomerName = @CustomerName, Address = @Address, Phone = @Phone, TaxNo = @TaxNo WHERE CustomerID = @CustomerID", con);
                cmd.Parameters.AddWithValue("CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("Address", customer.Address);
                cmd.Parameters.AddWithValue("Phone", customer.Phone);
                cmd.Parameters.AddWithValue("TaxNo", customer.TaxNo);
                cmd.Parameters.AddWithValue("CustomerID", customer.CustomerID);
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
        public Customer GetCustomerbyName(string CustomerName)
        {
            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE CustomerName = @CustomerName", con);
            cmd.Parameters.AddWithValue("CustomerName", CustomerName);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Customer customer = new Customer();
            if (sdr.HasRows)
            {
                sdr.Read();
                customer.CustomerID = (int)sdr["CustomerID"];
                customer.CustomerName = (string)sdr["CustomerName"];
                customer.Address = (string)sdr["Address"];
                customer.Phone = (string)sdr["Phone"];
                customer.TaxNo = (string)sdr["TaxNo"];
                return customer;
            }
            con.Close();
            return null;
        }
        public Customer GetCustomerbyID(int CustomerID)
        {
            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE CustomerID = @CustomerID", con);
            cmd.Parameters.AddWithValue("CustomerID", CustomerID);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Customer customer = new Customer();
            if (sdr.HasRows)
            {
                sdr.Read();
                customer.CustomerID = (int)sdr["CustomerID"];
                customer.CustomerName = (string)sdr["CustomerName"];
                customer.Address = (string)sdr["Address"];
                customer.Phone = (string)sdr["Phone"];
                customer.TaxNo = (string)sdr["TaxNo"];
                return customer;
            }
            con.Close();
            return null;
        }
        public List<Customer> GetAllCustomer()
        {
            string cs = CocBook.Properties.Settings.Default.connectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Customer> list = new List<Customer>();
            while (sdr.Read())
            {
                Customer customer = new Customer();
                customer.CustomerID = (int)sdr["CustomerID"];
                customer.CustomerName = (string)sdr["CustomerName"];
                customer.Address = (string)sdr["Address"];
                customer.Phone = (string)sdr["Phone"];
                customer.TaxNo = (string)sdr["TaxNo"];
                list.Add(customer);
            }
            con.Close();
            return list;
        }
    }
}
