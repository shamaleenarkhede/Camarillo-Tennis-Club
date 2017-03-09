using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Camarillo_Tennis_Club.Models
{
    public class PlayersDBContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CamarilloTennisClub"].ConnectionString;

        public int InsertPlayerDetails(Players players)
            {
              
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                SqlCommand cmd = new SqlCommand("spInsertPlayers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@FirstName";
                paramFirstName.Value = players.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = players.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@BirthDate";
                paramBirthDate.Value = players.BDate;
                cmd.Parameters.Add(paramBirthDate);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            }

              public DataSet GetPlayers()
              {
            
                 using (SqlConnection con = new SqlConnection(connectionString))
                 {
                    SqlCommand cmd = new SqlCommand("spGetPlayers", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
}