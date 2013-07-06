using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs.DTO;
using System.Data.SqlClient;

namespace DataAccessLayer.cs.DAL
{
    public class UserInfoDAL
    {
        
        public bool IsLogin(string username, string password)
        {
            try
            {
                string cs = CocBook.Properties.Settings.Default.connectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("SELECT COUNT (Username) FROM UserInfo WHERE Username = @username AND Password = @password", con);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return (count == 1);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
