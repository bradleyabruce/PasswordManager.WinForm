using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PasswordManager.WindowsApp.DAO
{
    class dataRetrieval
    {
        #region Variables

        dataLogin dl = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();
        string retrieveUrl = "https://74.140.136.128:1337/api/retrieval";

        #endregion

        #region GetPasswords              

        public async Task<List<PasswordObject>> getEntries(string userID, string categoryid)
        {
            string json = "{\"userid\": \"" + userID + "\", \"categoryid\": \"" + categoryid + "\"}";

            HttpWebRequest request = await Task.Run(() => dataUtility.SendHttp(json, retrieveUrl));

            //validate
            if (request == null)
            {
                
            }

            List<PasswordObject> listOfPasswords = await Task.Run(() => ReceiveSignUpHttp(request));

            //validate

            return listOfPasswords;
        }
        
        public List<PasswordObject> ReceiveSignUpHttp(HttpWebRequest request)
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

        #endregion

        #region Garbage

        //gets all categories and returns them in a list    
        public List<string> getCategories()
        {
            //store returned values
            List<string> catgories = new List<string>();

            //query to pass to database
            string queryString = "SELECT [CategoryName] FROM[PasswordManager].[dbo].[tCategories]";

            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {

                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();

                //query database
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    //return the userID of the username and password conbination
                    while (reader.Read())
                    {
                        catgories.Add(String.Format("{0}", reader["CategoryName"]));

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (catgories.Count == 0)
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            catgories.Insert(0, "None");
            return catgories;
        }

                                    


        //get all entries of user logins and passwords
        public DataSet getEntries(int CategoryID)
        {

            var query = "";

            //if user is searching for all entries 
            if (CategoryID == 0)
            {
                query = "SELECT dbo.tWebsiteDomains.WebsiteDomain, dbo.tWebsiteUsername.WebsiteUsername, dbo.tEntries.EntryID FROM dbo.tEntries INNER JOIN dbo.tWebsiteUsername ON dbo.tEntries.WebsiteUsernameID = dbo.tWebsiteUsername.WebsiteUsernameID INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID INNER JOIN dbo.tUsers ON dbo.tEntries.UserID = dbo.tUsers.UserID WHERE(dbo.tUsers.UserID = " + Program.MyStaticValues.userID + ")";
            }
            //if user is searching for specific category
            else
            {
               query = "SELECT dbo.tWebsiteDomains.WebsiteDomain, dbo.tWebsiteUsername.WebsiteUsername, dbo.tEntries.EntryID FROM dbo.tEntries INNER JOIN dbo.tWebsiteUsername ON dbo.tEntries.WebsiteUsernameID = dbo.tWebsiteUsername.WebsiteUsernameID INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID INNER JOIN dbo.tUsers ON dbo.tEntries.UserID = dbo.tUsers.UserID WHERE(dbo.tUsers.UserID = " + Program.MyStaticValues.userID + ") AND(dbo.tEntries.CategoryID =" + CategoryID + ")";
            }
            
           
            var dataAdapter = new SqlDataAdapter(query, dataUtility.getConnectionString());

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            //everything went well
            return ds;

            
        }




        public string getWebsitePassword(string entryID)
        {

            string websitePassword = "";

            //query to pass to database
            string queryString = "SELECT dbo.tWebsitePasswords.WebsitePassword, dbo.tEntries.EntryID FROM dbo.tEntries INNER JOIN dbo.tWebsitePasswords ON dbo.tEntries.WebsitePasswordID = dbo.tWebsitePasswords.WebsitePasswordID WHERE(dbo.tEntries.EntryID =" + entryID + ")";

            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {

                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();

                //query database
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    //return the userID of the username and password conbination
                    while (reader.Read())
                    {
                        websitePassword = String.Format("{0}", reader["WebsitePassword"]);

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (websitePassword == "")
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return websitePassword;


        }



        public int getEntryCategory(string entryID)
        {

            string stringCategoryID = "";
            int CategoryID = 0;

            //query to pass to database
            string queryString = "SELECT CategoryID FROM dbo.tEntries WHERE(EntryID =" + entryID + ")";

            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {

                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();

                //query database
                SqlDataReader reader = command.ExecuteReader();
                try
                {

                    //return the userID of the username and password conbination
                    while (reader.Read())
                    {
                        stringCategoryID = String.Format("{0}", reader["CategoryID"]);
                        CategoryID = int.Parse(stringCategoryID);

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (stringCategoryID == "")
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return CategoryID;





        }

        #endregion
    }
}

