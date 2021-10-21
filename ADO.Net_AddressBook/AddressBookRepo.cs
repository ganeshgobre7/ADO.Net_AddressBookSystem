using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO.Net_AddressBook
{
   public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-04NE37L;Initial Catalog=AddressBookDB;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);
        /// <summary>
        /// Method to Check Connection
        /// </summary>
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
            conn.Close();
        }
        /// <summary>
        /// Method for Creating Contact
        /// </summary>
        public void CreateContact()
        {
            Console.Write("Insert First Name :");
            string fname = Console.ReadLine();
            Console.Write("Insert Last Name :");
            string lname = Console.ReadLine();
            Console.Write("Insert Address : ");
            string address = Console.ReadLine();
            Console.Write("Insert City : ");
            string city = Console.ReadLine();
            Console.Write("Insert State : ");
            string state = Console.ReadLine();
            Console.Write("Insert ZIP : ");
            string zip = Console.ReadLine();
            Console.Write("Insert Phone Number : ");
            string phone = Console.ReadLine();
            Console.Write("Insert Email : ");
            string email = Console.ReadLine();

            try
            {
                SqlCommand command = new SqlCommand("SPCreateContact", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = state;
                command.Parameters.Add("@Zip", SqlDbType.VarChar).Value = zip;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;

                conn.Open();
                int count = command.ExecuteNonQuery();
                if (count != 0)
                    Console.WriteLine("Contact Created Successfully");
                else
                    Console.WriteLine("Failed to Create Contact");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); ;
            }
            conn.Close();
        }
        /// <summary>
        /// Method for Edit the Contact
        /// </summary>
        public void EditContact()
        {
            Console.Write("Insert Name to Edit Contact: ");
            string name = Console.ReadLine();
            Console.Write("Insert First Name :");
            string fname = Console.ReadLine();
            Console.Write("Insert Last Name :");
            string lname = Console.ReadLine();
            Console.Write("Insert Address : ");
            string address = Console.ReadLine();
            Console.Write("Insert City : ");
            string city = Console.ReadLine();
            Console.Write("Insert State : ");
            string state = Console.ReadLine();
            Console.Write("Insert ZIP : ");
            string zip = Console.ReadLine();
            Console.Write("Insert Phone Number : ");
            string phone = Console.ReadLine();
            Console.Write("Insert Email : ");
            string email = Console.ReadLine();

            try
            {
                conn.Open();
                string query = @"Update tbl_AddressBook Set FirstName =' "+fname+ "', LastName =' "+lname+" ', Address =' "+ address+"', City =' "+ city+"',State =' "+state+"', Zip =' "+ zip + "', PhoneNumber =' "+ phone + "',Email = '"+ email + "' where FirstName = '"+name+"';";
                SqlCommand command = new SqlCommand(query, conn);
                var result = command.ExecuteNonQuery();
                conn.Close();
                if (result != 0)
                    Console.WriteLine("Contact Updated Succesfully");
                else
                    Console.WriteLine("Failed to Update Contact");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
        }
    }
}
