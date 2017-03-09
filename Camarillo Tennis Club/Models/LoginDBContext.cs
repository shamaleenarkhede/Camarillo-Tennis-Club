using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Camarillo_Tennis_Club.Models
{
    public class LoginDBContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CamarilloTennisClub"].ConnectionString;

        public int InsertUserDetails(Login login)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertUserDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramUsername = new SqlParameter();
                paramUsername.ParameterName = "@Username";
                paramUsername.Value = login.Username;
                cmd.Parameters.Add(paramUsername);

                SqlParameter paramUserPassword = new SqlParameter();
                paramUserPassword.ParameterName = "@UserPassword";
                paramUserPassword.Value = login.UserPassword;
                cmd.Parameters.Add(paramUserPassword);

                SqlParameter paramUserrole = new SqlParameter();
                paramUserrole.ParameterName = "@Userrole";
                paramUserrole.Value = login.Userrole;
                cmd.Parameters.Add(paramUserrole);

                con.Open();
                int result = cmd.ExecuteNonQuery();

                return result;
            }
        }

        public DataSet getPassword(string Username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUserPassword", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramUsername = new SqlParameter();
                paramUsername.ParameterName = "@Username";
                paramUsername.Value = Username;
                cmd.Parameters.Add(paramUsername);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

           
        }
    }
}