using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    class dataDelete
    {
        #region Variables

        dataLogin dl = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();

        #endregion

        
        public bool deleteEntry(string entryID)
        {
            string domainID = "";
            string passwordID = "";
            string usernameID = "";

            //get ID of values in other tables to delete
            List<string> valuesToDelete = getValuesToDelete(entryID);
            for (int i = 0; i<3; i++)
            {
                if(i == 0)
                {
                    domainID = valuesToDelete.ElementAt(i);
                }
                if (i == 1)
                {
                    passwordID = valuesToDelete.ElementAt(i);
                }
                if (i == 2)
                {
                    usernameID = valuesToDelete.ElementAt(i);
                }
            }


            string query = "DELETE FROM [dbo].[tWebsiteDomains] WHERE WebsiteDomainID= @DomainID; DELETE FROM [dbo].[tWebsitePasswords] WHERE WebsitePasswordID= @PasswordID; DELETE FROM [dbo].[tWebsiteUsername] WHERE WebsiteUsernameID= @WebsiteUsernameID; DELETE FROM [dbo].[tEntries] WHERE EntryID= @entryID";
            
            

            using (SqlConnection conn = new SqlConnection(dataUtility.getConnectionString()))
            {


                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@DomainID", domainID);
                    command.Parameters.AddWithValue("@PasswordID", passwordID);
                    command.Parameters.AddWithValue("@WebsiteUsernameID", usernameID);
                    command.Parameters.AddWithValue("@entryID", entryID);
                    conn.Open();
                    command.ExecuteNonQuery();

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();

                    return true;

                }
            }

        }





        public List<string> getValuesToDelete(string entryID)
        {


            List<string> valuesToDelete = new List<string>();

            //query to pass to database
            string queryString = "SELECT dbo.tWebsiteDomains.WebsiteDomainID, dbo.tWebsitePasswords.WebsitePasswordID, dbo.tWebsiteUsername.WebsiteUsernameID FROM dbo.tEntries INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID INNER JOIN dbo.tWebsitePasswords ON dbo.tEntries.WebsitePasswordID = dbo.tWebsitePasswords.WebsitePasswordID INNER JOIN dbo.tWebsiteUsername ON dbo.tEntries.WebsiteUsernameID = dbo.tWebsiteUsername.WebsiteUsernameID WHERE(dbo.tEntries.EntryID =" + entryID + ")";

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

                        string domainID = String.Format("{0}", reader["WebsiteDomainID"]);
                        string passwordID = String.Format("{0}", reader["WebsitePasswordID"]);
                        string usernameID = String.Format("{0}", reader["WebsiteUsernameID"]);

                        valuesToDelete.Add(domainID);
                        valuesToDelete.Add(passwordID);
                        valuesToDelete.Add(usernameID);
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



    }
}
