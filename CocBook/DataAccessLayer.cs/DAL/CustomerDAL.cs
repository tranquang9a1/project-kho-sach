﻿using System;
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
                //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                SqlConnection con = new SqlConnection(@"Server=QUANGTVSE61078\SQLEXPRESS;Database = CocBook;uid=sa;pwd=vinhquang");
                SqlCommand cmd = new SqlCommand("Insert into Customer values (@CustomerID, @CustomerName, @Address, @Phone, @TaxNo)", con);
                cmd.Parameters.AddWithValue("CustomerID", customer.CustomerID);
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
            try
            {
                SqlConnection con = new SqlConnection(@"Server=QUANGTVSE61078\SQLEXPRESS;Database = CocBook;uid=sa;pwd=vinhquang");
                //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                //SqlConnection con = new SqlConnection(cs);
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
                SqlConnection con = new SqlConnection(@"Server=QUANGTVSE61078\SQLEXPRESS;Database = CocBook;uid=sa;pwd=vinhquang");
                //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
                //SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Update Customer set CustomerName = @CustomerName, Address = @Address, Phone = @Phone, TaxNo = @TaxNo where CustomerID = @CustomerID", con);
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
        public Customer GetCustomerbyID(string CustomerID)
        {
            SqlConnection con = new SqlConnection(@"Server=QUANGTVSE61078\SQLEXPRESS;Database = CocBook;uid=sa;pwd=vinhquang");
            //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            //SqlConnection con = new SqlConnection(cs);
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
            SqlConnection con = new SqlConnection(@"Server=QUANGTVSE61078\SQLEXPRESS;Database = CocBook;uid=sa;pwd=vinhquang");
            //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            //SqlConnection con = new SqlConnection(cs);
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