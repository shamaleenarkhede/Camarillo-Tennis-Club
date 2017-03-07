using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Camarillo_Tennis_Club.Models
{
    public class ScoresDBContext
    {

        public int InsertScores(AddNewMatchViewModel addNewMatchViewModel)
        {
            int result=0, PlayerID=0;
            string connectionString = ConfigurationManager.ConnectionStrings["CamarilloTennisClub"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                for (int i = 0; i < addNewMatchViewModel.scoreList.Count; i++)
                {
                    if (i == 0)
                    {
                        PlayerID = addNewMatchViewModel.Player1ID;
                    }
                    else
                    {
                        PlayerID = addNewMatchViewModel.Player2ID;
                    }
                    SqlCommand cmd = new SqlCommand("spInsertScores", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter paramMatchID = new SqlParameter();
                    paramMatchID.ParameterName = "@MatchID";
                    paramMatchID.Value = addNewMatchViewModel.MatchID;
                    cmd.Parameters.Add(paramMatchID);

                    SqlParameter paramPlayerID = new SqlParameter();
                    paramPlayerID.ParameterName = "@PlayerID";
                    paramPlayerID.Value = PlayerID;
                    cmd.Parameters.Add(paramPlayerID);

                    SqlParameter paramSet1Score = new SqlParameter();
                    paramSet1Score.ParameterName = "@Set1Score";
                    paramSet1Score.Value = addNewMatchViewModel.scoreList[i].Set1Score;
                    cmd.Parameters.Add(paramSet1Score);

                    SqlParameter paramSet2Score = new SqlParameter();
                    paramSet2Score.ParameterName = "@Set2Score";
                    paramSet2Score.Value = addNewMatchViewModel.scoreList[i].Set2Score;
                    cmd.Parameters.Add(paramSet2Score);

                    SqlParameter paramSet3Score = new SqlParameter();
                    paramSet3Score.ParameterName = "@Set3Score";
                    paramSet3Score.Value = addNewMatchViewModel.scoreList[i].Set3Score;
                    cmd.Parameters.Add(paramSet3Score);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return result;
            }
        }
    }
}