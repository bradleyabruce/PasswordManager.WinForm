using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script;
using System.Web.Script.Serialization;


namespace PasswordManager.WindowsApp.DAO
{
    class dataLogin
    {

        public string loginUrl = "http://74.140.136.128:1337/api/login";
        public string checkUrl = "http://http://74.140.136.128:1337/product";


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

            return true;
        }






        //this class will retrieve database information from txt file
        public string getConnectionString()
        {
            string connectionString = "";

            try
            {
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
        }




        //connect to database with login
        public async Task<bool> loginToDatabase(string email, string hashedPassword)
        {

            string userID = "";
            string userEmail = "";
            string userPassword = "";
            string result;

            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => SendLoginHttp(json));

            //validate request

            LoginObject loginObject = await Task.Run(() => ReceiveResponse(request));

            //validate response

            userID = loginObject.UserID;
            userEmail = loginObject.UserLoginEmail;
            userPassword = loginObject.UserLoginPassword;
            
            if(userEmail == email && userPassword == hashedPassword)
            {

                if (userID != "")
                {
                    Program.MyStaticValues.userID = int.Parse(userID);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }



        public HttpWebRequest SendLoginHttp(string json)
        {

            Uri uri = new Uri(loginUrl);
            var builder = new UriBuilder(uri);
            builder.Port = 1337;
            uri = builder.Uri;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return request;
        }


        public LoginObject ReceiveResponse(HttpWebRequest request)
        {
            string result;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            var serializer = new JavaScriptSerializer();
            var loginObjects = serializer.Deserialize<List<LoginObject>>(result);

            return loginObjects[0];
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
