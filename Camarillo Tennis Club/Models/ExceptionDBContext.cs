using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Camarillo_Tennis_Club.Models
{
    public class ExceptionDBContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CamarilloTennisClub"].ConnectionString;

        public int InsertExceptions(ExceptionLogger exceptionLogger)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
           {
                SqlCommand cmd = new SqlCommand("spInsertPlayers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramExceptionMessage = new SqlParameter();
                paramExceptionMessage.ParameterName = "@ExceptionMessage";
                paramExceptionMessage.Value = exceptionLogger.ExceptionMessage;
                cmd.Parameters.Add(paramExceptionMessage);

                SqlParameter paramControllerName = new SqlParameter();
                paramControllerName.ParameterName = "@ControllerName";
                paramControllerName.Value = exceptionLogger.ControllerName;
                cmd.Parameters.Add(paramControllerName);


                SqlParameter paramExceptionStackTrace = new SqlParameter();
                paramExceptionStackTrace.ParameterName = "@ExceptionStackTrace";
                paramExceptionStackTrace.Value = exceptionLogger.ExceptionMessage;
                cmd.Parameters.Add(paramExceptionStackTrace);
                
                SqlParameter paramLogTime = new SqlParameter();
                paramLogTime.ParameterName = "@LogTime";
                paramLogTime.Value = exceptionLogger.ExceptionMessage;
                cmd.Parameters.Add(paramLogTime);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }

        }
}