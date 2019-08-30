using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PasswordManager.WindowsApp.DAO
{
    class dataRetrieval
    {
        #region Variables

        dataLogin dl = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();
        string retrieveUrl = "https://174.101.154.93:1337/api/entryRetrieval";
        string categoryUrl = "https://174.101.154.93:1337/api/categoryRetrieval";

        #endregion

        #region GetData           

        public async Task<List<PasswordObject>> getEntries(string userID, string categoryid)
        {
            string json = "{\"userid\": \"" + userID + "\", \"categoryid\": \"" + categoryid + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, retrieveUrl));

            //validate
            if (request == null)
            {

            }

            List<PasswordObject> listOfPasswords = await Task.Run(() => ReceiveEntriesHttp(request));

            //validate

            return listOfPasswords;
        }

        public List<PasswordObject> ReceiveEntriesHttp(HttpWebRequest request)
        {
            List<PasswordObject> listOfPasswords = new List<PasswordObject>();
            string result = "";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            if (result == @"""No Results""")
            {
                listOfPasswords.Clear();
                PasswordObject noResultObject = new PasswordObject();
                noResultObject.Status = "No Results";
                listOfPasswords.Add(noResultObject);
                return listOfPasswords;
            }

            else
            {
                try
                {
                    var serializer = new JavaScriptSerializer();
                    listOfPasswords = serializer.Deserialize<List<PasswordObject>>(result);
                }

                catch (Exception Ex)
                {
                    listOfPasswords.Clear();
                    PasswordObject failureObject = new PasswordObject();
                    failureObject.Status = "Issue";
                    listOfPasswords.Add(failureObject);
                    return listOfPasswords;
                }
            }

            return listOfPasswords;
        }

        public async Task<List<CategoryObject>> getCategories(string userID)
        {
            string json = "{\"userid\": \"" + userID + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, categoryUrl));

            //validate
            if (request == null)
            {

            }

            List<CategoryObject> listOfCategories = await Task.Run(() => ReceiveCategoriesHttp(request));

            //validate

            return listOfCategories;
        }

        public List<CategoryObject> ReceiveCategoriesHttp(HttpWebRequest request)
        {
            List<CategoryObject> listOfCategories = new List<CategoryObject>();
            string result = "";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            if (result == @"""No Results""")
            {

            }

            else
            {
                try
                {
                    var serializer = new JavaScriptSerializer();
                    listOfCategories = serializer.Deserialize<List<CategoryObject>>(result);
                }

                catch (Exception Ex)
                {
                    listOfCategories.Clear();
                    //PasswordObject failureObject = new PasswordObject();
                    //failureObject.Status = "Issue";
                   // listOfCategories.Add(failureObject);
                    return listOfCategories;
                }
            }
            return listOfCategories;
        }

        #endregion

    }
}

