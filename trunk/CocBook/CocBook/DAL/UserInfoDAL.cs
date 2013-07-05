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
        public List<UserInfo> GetAllUserInfo()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserInfo", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<UserInfo> list = new List<UserInfo>();
            while (sdr.Read())
            {
                UserInfo userInfo = new UserInfo();
                userInfo.Username = (string)sdr["Username"];
                userInfo.Password = (string)sdr["Password"];
                list.Add(userInfo);
            }
            con.Close();
            return list;
        }
        public bool IsLogin(string username, string password)
        {
            try
            {
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
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
