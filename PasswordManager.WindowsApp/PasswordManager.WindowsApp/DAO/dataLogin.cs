using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script;
using System.Web.Script.Serialization;

namespace PasswordManager.WindowsApp.DAO
{
    class dataLogin
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
                string path = "..\\..\\..\\sqlServerConnection.txt";

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
        public bool loginToDatabase(string email, string hashedPassword)
        {
            string userID;
            string LoginEmail;
            string LoginPassword;

            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            byte[] jsonArray = Encoding.UTF8.GetBytes(json);
            int length = jsonArray.Length;
            
            string url = "http://74.140.136.128:1337/api/login";
            Uri uri = new Uri(url);
            var builder = new UriBuilder(uri);
            builder.Port = 1337;
            uri = builder.Uri;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(jsonArray, 0, length);
                }
            }
            catch(Exception e)
            {
                return false;
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Dictionary<string, string> JSONObject = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(responseString);
            userID = JSONObject["UserID"];
            LoginEmail = JSONObject["UserLoginEmail"];
            LoginPassword = JSONObject["UserLoginPassword"];

            /*
            //store userID
            string userID = "";

            //query to pass to database
            string queryString = "SELECT [UserID],[UserLoginEmail],[UserLoginPassword] FROM[PasswordManager].[dbo].[tUsers] WHERE UserLoginEmail = @email AND UserLoginPassword = @password";
            
            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {

                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", hashedPassword);
                conn.Open();

                //query database
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    //return the userID of the username and password conbination
                    while (reader.Read())
                    {
                        //userID = (String.Format("{0}, {1}", reader["UserID"], reader["UserLoginPassword"]));
                        userID = (String.Format("{0}", reader["UserID"]));

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
            //store user ID in global spot
            //return true   
            Program.MyStaticValues.userID = int.Parse(userID);
            */
            return true;
        }




        
        public int Register(string email, string hashedPassword)
        {

            string query = "INSERT INTO [dbo].[tUsers] (UserLoginEmail, UserLoginPassword) VALUES (@UserLoginEmail, @UserLoginPassword); SELECT SCOPE_IDENTITY()";

            int returnedID = 0;

            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@UserLoginEmail", email);
                    command.Parameters.AddWithValue("@UserLoginPassword", hashedPassword);

                    conn.Open();

                    returnedID = Convert.ToInt32(command.ExecuteScalar());

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();

                    return returnedID;

                }
            }




        }
        



        public string EncodePassword(string password)
        {

            byte[] tempSource;
            byte[] tempHash;

            tempSource = UTF8Encoding.UTF8.GetBytes(password);

            //compute hash
            tempHash = new SHA1CryptoServiceProvider().ComputeHash(tempSource);

            StringBuilder build = new StringBuilder(tempHash.Length);
            for (int i = 0; i<tempHash.Length; i++)
            {
                build.Append(tempHash[i].ToString("X2"));
            }

            return build.ToString(); ;
        }



    }
}
