using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{

    class dataRetrieval
    {

        dataLogin dl = new dataLogin();



        //gets all categories and returns them in a list    
        public List<string> getCategories()
        {
            //store returned values
            List<string> catgories = new List<string>();

            //query to pass to database
            string queryString = "SELECT [CategoryName] FROM[PasswordManager].[dbo].[tCategories]";

            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(dl.getConnectionString()))
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
            catgories.Insert(0, "All");
            return catgories;
        }





        public List<String> getEntries(int CategoryID)
        {

            List<string> entries = new List<string>();
            //List<string> WebsiteUsernameIDs = new List<string>();

            string queryString = "";

            //if user is searching for all entries 
            if (CategoryID == 0)
            {
                queryString = "SELECT dbo.tWebsiteDomains.WebsiteDomain, dbo.tEntries.WebsiteUsernameID FROM dbo.tEntries INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID";
            }
            //if user is searching for specific category
            else
            {
                queryString = "SELECT dbo.tWebsiteDomains.WebsiteDomain FROM dbo.tEntries INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID INNER JOIN dbo.tCategories ON dbo.tEntries.CategoryID = dbo.tCategories.CategoryID WHERE(dbo.tCategories.CategoryID =" + CategoryID + ")";
            }
            


            //pass values to sql server
            using (SqlConnection conn = new SqlConnection(dl.getConnectionString()))
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
                        //get entries and websiteUsernameIDs
                        entries.Add(String.Format("{0}", reader["WebsiteDomain"]));
                        //WebsiteUsernameIDs.Add(String.Format("{0}", reader["WebsiteUsernameID"]));
                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (entries.Count == 0)
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return entries;

            
        }




    }




}

