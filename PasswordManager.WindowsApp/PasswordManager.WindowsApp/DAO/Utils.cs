using System;
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



    }
}
