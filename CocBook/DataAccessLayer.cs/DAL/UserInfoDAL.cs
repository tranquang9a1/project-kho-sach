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
            // ConnectionString to DB
            /*ConnectionString Error
            string cs = ConfigurationManager.ConnectionStrings["BookStoreCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            */
            SqlConnection con = new SqlConnection(@"Server=(local);Database = CocBook;uid=sa;pwd=123456789");
            //
            // View all Command
            SqlCommand cmd = new SqlCommand("SELECT * from UserInfo", con);
            //
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
    }
}
