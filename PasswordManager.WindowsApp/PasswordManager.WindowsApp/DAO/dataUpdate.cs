using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    class dataUpdate
    {

        dataLogin dl = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();


        //get values from entry to find changes
        public List<string> getValuesToUpdate(string entryID)
        {


            List<string> valuesToDelete = new List<string>();

            //query to pass to database
            string queryString = "SELECT dbo.tWebsitePasswords.WebsitePassword, dbo.tWebsiteUsername.WebsiteUsername, dbo.tWebsitePasswords.WebsitePasswordID, dbo.tWebsiteUsername.WebsiteUsernameID, dbo.tEntries.CategoryID FROM dbo.tEntries INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID INNER JOIN dbo.tWebsitePasswords ON dbo.tEntries.WebsitePasswordID = dbo.tWebsitePasswords.WebsitePasswordID INNER JOIN dbo.tWebsiteUsername ON dbo.tEntries.WebsiteUsernameID = dbo.tWebsiteUsername.WebsiteUsernameID WHERE(dbo.tEntries.EntryID = " + entryID + ")";

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
                        string password = String.Format("{0}", reader["WebsitePassword"]);
                        string username = String.Format("{0}", reader["WebsiteUsername"]);
                        string passwordID = String.Format("{0}", reader["WebsitePasswordID"]);
                        string usernameID = String.Format("{0}", reader["WebsiteUsernameID"]);
                        string categoryID = String.Format("{0}", reader["CategoryID"]);


                        valuesToDelete.Add(password);
                        valuesToDelete.Add(username);
                        valuesToDelete.Add(passwordID);
                        valuesToDelete.Add(usernameID);
                        valuesToDelete.Add(categoryID);

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (valuesToDelete.Count == 0)
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return valuesToDelete;
        }




        public bool updatePassword(string passwordID, string newPassword)
        {

            string query = "UPDATE dbo.tWebsitePasswords SET WebsitePassword = @newPassword WHERE WebsitePasswordID = @passwordID";

            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    command.Parameters.AddWithValue("@passwordID", passwordID);
                    conn.Open();
                    command.ExecuteNonQuery();

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                }

                return true;

            }


        }//end updatePassword()




        public bool updateUsername(string usernameID, string newUsername)
        {

            string query = "UPDATE dbo.tWebsiteUsername SET WebsiteUsername = @newUsername WHERE WebsiteUsernameID = @usernameID";

            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@newUsername", newUsername);
                    command.Parameters.AddWithValue("@usernameID", usernameID);
                    conn.Open();
                    command.ExecuteNonQuery();

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                }

                return true;

            }


        }//end updateUsername()


        public bool updateCategoryID(string entryID, string newCategoryID)
        {

            string query = "UPDATE dbo.tEntries SET CategoryID = @newCategoryID WHERE EntryID = @entryID";

            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@newCategoryID", newCategoryID);
                    command.Parameters.AddWithValue("@entryID", entryID);
                    conn.Open();
                    command.ExecuteNonQuery();

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                }

                return true;

            }


        }//end updateUsername()



    }
}