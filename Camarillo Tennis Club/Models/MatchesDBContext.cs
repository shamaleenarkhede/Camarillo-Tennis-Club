﻿using System;
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

        public int InsertMatchDetails(AddNewMatchViewModel addNewMatchViewModel)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CamarilloTennisClub"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertMatches", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramLocation = new SqlParameter();
                paramLocation.ParameterName = "@Location";
                paramLocation.Value = addNewMatchViewModel.Location;
                cmd.Parameters.Add(paramLocation);


                SqlParameter paramMatchDate = new SqlParameter();
                paramMatchDate.ParameterName = "@MatchDate";
                paramMatchDate.Value = addNewMatchViewModel.MatchDate;
                cmd.Parameters.Add(paramMatchDate);


                SqlParameter paramPlayer1ID = new SqlParameter();
                paramPlayer1ID.ParameterName = "@Player1ID";
                paramPlayer1ID.Value = addNewMatchViewModel.Player1ID;
                cmd.Parameters.Add(paramPlayer1ID);


                SqlParameter paramPlayer2ID = new SqlParameter();
                paramPlayer2ID.ParameterName = "@Player2ID";
                paramPlayer2ID.Value = addNewMatchViewModel.Player2ID;
                cmd.Parameters.Add(paramPlayer2ID);

                SqlParameter paramWinnerID = new SqlParameter();
                paramWinnerID.ParameterName = "@WinnerID";
                paramWinnerID.Value = addNewMatchViewModel.WinnerID;
                cmd.Parameters.Add(paramWinnerID);

                //var returnParameter = cmd.Parameters.Add("@RetVal", SqlDbType.Int);
                //returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                //  cmd.ExecuteNonQuery();
                int result = (int)cmd.ExecuteScalar(); 

                return result;
            }
            }
        }
}