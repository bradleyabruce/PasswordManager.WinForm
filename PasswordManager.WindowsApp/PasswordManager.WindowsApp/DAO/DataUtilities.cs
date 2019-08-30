using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    public class DataUtilities
    {
        #region Utilities

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

        public bool databaseCheck()
        {
            TrustHttps.IgnoreBadCertificates();

            try
            {
                string result;
                Uri uri = CreateURI("https://174.101.154.93:1337/api/test");

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
    }
}
