using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Camarillo_Tennis_Club.Models
{
    public class MatchesDBContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CamarilloTennisClub"].ConnectionString;

        public int InsertMatchDetails(Matches matches)
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertMatches", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramLocation = new SqlParameter();
                paramLocation.ParameterName = "@Location";
                paramLocation.Value = matches.Location;
                cmd.Parameters.Add(paramLocation);


                SqlParameter paramMatchDate = new SqlParameter();
                paramMatchDate.ParameterName = "@MatchDate";
                paramMatchDate.Value = matches.MatchDate;
                cmd.Parameters.Add(paramMatchDate);


                SqlParameter paramPlayer1ID = new SqlParameter();
                paramPlayer1ID.ParameterName = "@Player1ID";
                paramPlayer1ID.Value = matches.Player1ID;
                cmd.Parameters.Add(paramPlayer1ID);


                SqlParameter paramPlayer2ID = new SqlParameter();
                paramPlayer2ID.ParameterName = "@Player2ID";
                paramPlayer2ID.Value = matches.Player2ID;
                cmd.Parameters.Add(paramPlayer2ID);

                SqlParameter paramWinnerID = new SqlParameter();
                paramWinnerID.ParameterName = "@WinnerID";
                paramWinnerID.Value = matches.WinnerID;
                cmd.Parameters.Add(paramWinnerID);
                con.Open();

                int result = (int)cmd.ExecuteScalar(); 

                return result;
            }
            }

        public int UpdateMatchDetails(Matches matches)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateMatchDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramLocation = new SqlParameter();
                paramLocation.ParameterName = "@Location";
                paramLocation.Value = matches.Location;
                cmd.Parameters.Add(paramLocation);


                SqlParameter paramMatchDate = new SqlParameter();
                paramMatchDate.ParameterName = "@MatchDate";
                paramMatchDate.Value = matches.MatchDate;
                cmd.Parameters.Add(paramMatchDate);


                SqlParameter paramPlayer1ID = new SqlParameter();
                paramPlayer1ID.ParameterName = "@Player1ID";
                paramPlayer1ID.Value = matches.Player1ID;
                cmd.Parameters.Add(paramPlayer1ID);


                SqlParameter paramPlayer2ID = new SqlParameter();
                paramPlayer2ID.ParameterName = "@Player2ID";
                paramPlayer2ID.Value = matches.Player2ID;
                cmd.Parameters.Add(paramPlayer2ID);

                SqlParameter paramWinnerID = new SqlParameter();
                paramWinnerID.ParameterName = "@WinnerID";
                paramWinnerID.Value = matches.WinnerID;
                cmd.Parameters.Add(paramWinnerID);

                SqlParameter paramMatchID = new SqlParameter();
                paramMatchID.ParameterName = "@MatchID";
                paramMatchID.Value = matches.MatchID;
                cmd.Parameters.Add(paramMatchID);

                con.Open();
                int result = cmd.ExecuteNonQuery();

                return result;
            }
        }


        public DataSet GetMatchesPlayers()
            {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchesPlayers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetMatchUsingSearchString(string SearchString)
        {
          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchesUsingSearchString", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramSearchString = new SqlParameter();
                paramSearchString.ParameterName = "@SearchString";
                paramSearchString.Value = SearchString;
                cmd.Parameters.Add(paramSearchString);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}