using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeManagement
{


	public class SqlOperation
	{
		public static int SqlInsert(String command)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
            int RowsAffected;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {

                    SqlCommand cmd = new SqlCommand(command, connection);
                    connection.Open();
                     RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;

                }
            }catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return RowsAffected = 0;
            }
            
        }
	}
}