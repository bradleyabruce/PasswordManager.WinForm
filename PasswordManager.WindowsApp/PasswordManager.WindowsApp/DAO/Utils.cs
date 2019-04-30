﻿using System;
using System.Data.SqlClient;
using System.IO;


namespace PasswordManager.WindowsApp.DAO
{
    class Utils
    {

        //this class checks the sql database and returns true if the server is online and false if not  
        public bool databaseCheck()
        {

            string connectionString = getConnectionString();


            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();
                
            }
            catch(Exception e)
            {
                return false;
            }


            return true; ;
        }






        //this class will retrieve database information from txt file
        public string getConnectionString()
        {

            string connectionString = "";

            try
            {

                //change this file name to point to a different text file with database connection string  
                string path = "..\\..\\demoSqlServerConnection.txt";

                using (StreamReader sr = new StreamReader(path))
                {

                    string stringFromFile = sr.ReadLine();
                    connectionString = stringFromFile;

                }

            }//end try

            catch(Exception e)
            {
                return "File Not Found";
            }//end catch


            return connectionString;

            //return "";
        }




        //connect to database with login
        public bool loginToDatabase(string inputUsername, string inputPassword)
        {
            //store userID
            string userID = "";

            //query to pass to database
            string queryString = "SELECT [UserID],[UserLoginEmail],[UserLoginPassword] FROM[PasswordManager].[dbo].[tUsers] WHERE UserLoginEmail = @user AND UserLoginPassword = @password";
            
            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {

                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@user", inputUsername);
                command.Parameters.AddWithValue("@password", inputPassword);
                conn.Open();

                //query database
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    //return the userID of the username and password conbination
                    while (reader.Read())
                    {
                        userID = (String.Format("{0}, {1}", reader["UserID"], reader["UserLoginPassword"]));     

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (userID == "" || userID == null)
                    {
                        return false;
                    }

                }

                //something went wrong
                catch(Exception e)
                {
                    return false;
                }
                
            }

            //everything went well
            return true;
        }



    }
}