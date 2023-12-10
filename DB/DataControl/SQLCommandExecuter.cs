using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DB.DataControl
{
    public class SQLCommandExecuter
    {
        private int ReturnVal = 0;
        public void ExecuteNonQuery(string command)
        {
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand myCommand = new SqlCommand(command, connection);
            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public int SelectReturn(string command)
        {
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);


            SqlCommand myCommand = new SqlCommand(command, connection);
            try
            {
                connection.Open();
                ReturnVal = myCommand.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return ReturnVal;
        }
    }
}
