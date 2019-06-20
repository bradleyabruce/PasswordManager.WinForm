using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace PasswordManager.WindowsApp.DAO
{
    class dataLogin
    {
        #region Variables

        public string loginUrl = "http://74.140.136.128:1337/api/login";
        public string statusUrl = "http://74.140.136.128:1337/api/test";
        public string signUpUrl = "http://74.140.136.128:1337/api/signUp";

        #endregion

        #region Status

        public bool databaseCheck()
        {
            try
            {
                string result;
                Uri uri = CreateURI(statusUrl);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                if (result != "OK")
                {
                    return false;
                }
            }
            catch (Exception e)
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
            }
            catch (Exception e)
            {
                return "File Not Found";
            }
            return connectionString;
        }

        #endregion

        #region Login

        //connect to database with login
        public async Task<bool> loginToDatabase(string email, string hashedPassword)
        {
            string userID = "";
            string userEmail = "";
            string userPassword = "";

            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => SendHttp(json, loginUrl));

            //validate
            if (request == null)
            {
                return false;
            }

            LoginObject loginObject = await Task.Run(() => ReceiveLoginHttp(request));

            //validate
            if (loginObject.Status == false)
            {
                return false;
            }
            else
            {
                userID = loginObject.UserID;
                userEmail = loginObject.UserLoginEmail;
                userPassword = loginObject.UserLoginPassword;

                if (userEmail == email && userPassword == hashedPassword)
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
        }

        public HttpWebRequest SendHttp(string json, string url)
        {

            Uri uri = CreateURI(url);

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

        public LoginObject ReceiveLoginHttp(HttpWebRequest request)
        {
            string result;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            try
            {
                var serializer = new JavaScriptSerializer();
                var loginObjects = serializer.Deserialize<List<LoginObject>>(result);

                loginObjects[0].Status = true;
                return loginObjects[0];
            }
            catch (Exception Ex)
            {
                LoginObject errorObject = new LoginObject();
                errorObject.Status = false;
                return errorObject;
            }
        }

        #endregion

        #region signUp

        public async Task<int> signUp(string email, string hashedPassword)
        {

            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => SendHttp(json, signUpUrl));

            //validate
            if (request == null)
            {
                return -1;
            }

            int UserID = await Task.Run(() => ReceiveSignUpHttp(request));

            //validate
            if (UserID == -1)
            {
                return -1;
            }

            return UserID;
        }

        public int ReceiveSignUpHttp(HttpWebRequest request)
        {
            string result;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            try
            {
                var serializer = new JavaScriptSerializer();
                var UserID = serializer.Deserialize<List<String>>(result);

                result = UserID[0];
            }
            catch (Exception Ex)
            {
                return -1;
            }

            return int.Parse(result);
        }






        #endregion

        #region Utilities

        public string EncodePassword(string password)
        {

            byte[] tempSource;
            byte[] tempHash;

            tempSource = UTF8Encoding.UTF8.GetBytes(password);

            //compute hash
            tempHash = new SHA1CryptoServiceProvider().ComputeHash(tempSource);

            StringBuilder build = new StringBuilder(tempHash.Length);
            for (int i = 0; i < tempHash.Length; i++)
            {
                build.Append(tempHash[i].ToString("X2"));
            }

            return build.ToString(); ;
        }



        public Uri CreateURI(string url)
        {
            Uri uri = new Uri(url);
            var builder = new UriBuilder(uri);
            builder.Port = 1337;
            uri = builder.Uri;
            return uri;
        }

        #endregion

    }
}
