using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace PasswordManager.WindowsApp.DAO
{
    class dataLogin
    {
        #region Variables

        DataUtilities dataUtility = new DataUtilities();
        public string loginUrl = "https://174.101.154.93:1337/api/login";
        public string signUpUrl = "https://174.101.154.93:1337/api/signUp";

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
            List<string> returnedList = new List<string>();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            try
            {
               if(result == "Email and password Required")
               {
                   return -1;
               }
               else
               {
                    return 1;
               }
            }
            catch (Exception Ex)
            {
                return -1;
            }
        }






        #endregion
    }
}
