using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DTO;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer.DAL
{
    class CustomerDAL
    {
        public bool CreateCustomer(Customer customer)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Insert into Customer values (@ID, @Name, @Address, @Phone, @TaxNo)", con);
                cmd.Parameters.AddWithValue("ID", customer.CustomerID);
                cmd.Parameters.AddWithValue("Name", customer.CustomerName);
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
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Delete from Customer where CustomerID = @ID", con);
                cmd.Parameters.AddWithValue("ID", CustomerID);
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
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Update Customer set CustomerName = @Name, Address = @Address, Phone = @Phone, TaxNo = @TaxNo where CustomerID = @ID", con);
                cmd.Parameters.AddWithValue("Name", customer.CustomerName);
                cmd.Parameters.AddWithValue("Address", customer.Address);
                cmd.Parameters.AddWithValue("Phone", customer.Phone);
                cmd.Parameters.AddWithValue("TaxNo", customer.TaxNo);
                cmd.Parameters.AddWithValue("ID", customer.CustomerID);
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
        public Customer GetCustomerbyID(int CustomerID)
        {
            
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Select * from Customer where CustomerID = @ID", con);
                cmd.Parameters.AddWithValue("ID", CustomerID);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                Customer customer = new Customer();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    customer.CustomerName = (string)sdr["CustomerName"];
                    customer.Address = (string)sdr["Address"];
                    customer.Phone = (string)sdr["Phone"];
                    customer.TaxNo = (string)sdr["TaxNo"];
                    customer.CustomerID = (string)sdr["CustomerID"];
                    return customer;
                }
                con.Close();
                return null;
            }
        public List<Customer> GetAllCustomer()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Customer", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Customer> list = new List<Customer>();
            while (sdr.Read())
            {
                Customer customer = new Customer();
                customer.CustomerName = (string)sdr["CustomerName"];
                customer.Address = (string)sdr["Address"];
                customer.Phone = (string)sdr["Phone"];
                customer.TaxNo = (string)sdr["TaxNo"];
                customer.CustomerID = (string)sdr["CustomerID"];
                list.Add(customer);
            }
            con.Close();
            return list;
        }
            
                
                
           
            

        }
    }

