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

        DataUtilities dataUtility = new DataUtilities();
        public string loginUrl = "https://74.140.136.128:1337/api/login";
        public string signUpUrl = "https://74.140.136.128:1337/api/signUp";

        #endregion

        #region Login

        //connect to database with login
        public async Task<bool> loginToDatabase(string email, string hashedPassword)
        {
            string userID = "";
            string userEmail = "";
            string userPassword = "";

            string json = "{\"email\": \"" + email + "\", \"password\": \"" + hashedPassword + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, loginUrl));

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

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, signUpUrl));

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
    }
}
