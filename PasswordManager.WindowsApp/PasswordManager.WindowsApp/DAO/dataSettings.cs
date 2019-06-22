using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    class dataSettings
    {

        dataLogin dl = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();




        public string getUsername(string userID)
        {

            string username = "";

            //query to pass to database
            string queryString = "SELECT UserLoginEmail FROM dbo.tUsers WHERE(UserID =" + userID + ");";

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
                        username = String.Format("{0}", reader["UserLoginEmail"]);

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (username == "")
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return username;

        }





        public List<string> getEntriesToDelete(string userID)
        {
            List<string> entriesToDelete = new List<string>();

            //query to pass to database
            string queryString = "SELECT dbo.tEntries.EntryID FROM dbo.tEntries INNER JOIN dbo.tUsers ON dbo.tEntries.UserID = dbo.tUsers.UserID WHERE(dbo.tUsers.UserID =" + userID + ")";

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

                        string entryID = String.Format("{0}", reader["EntryID"]);

                        entriesToDelete.Add(entryID);
                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (entriesToDelete.Count == 0)
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return entriesToDelete;
        }



    }
}
