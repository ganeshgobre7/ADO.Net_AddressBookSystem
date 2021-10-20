using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO.Net_AddressBook
{
   public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-04NE37L;Initial Catalog=AddressBookSystemDB;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);

        public void DBCOnnection()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection has been Created SuccessFully");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Connection Not Established");
            }
        }
    }
}
