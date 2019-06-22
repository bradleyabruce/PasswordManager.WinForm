using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{

    class dataExport
    {

        dataLogin dl = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();

        public string getCSVData(string userID)
        {

            string websiteDomain = "";
            string websiteUsername = "";
            string websitePassword = "";

            string CSV = "WebsiteDomain,WebsiteUsername,WebsitePassword\n";

            //query to pass to database
            string queryString = "SELECT dbo.tWebsiteDomains.WebsiteDomain, dbo.tWebsiteUsername.WebsiteUsername, dbo.tWebsitePasswords.WebsitePassword FROM dbo.tEntries INNER JOIN dbo.tWebsiteDomains ON dbo.tEntries.WebsiteDomainID = dbo.tWebsiteDomains.WebsiteDomainID INNER JOIN dbo.tWebsitePasswords ON dbo.tEntries.WebsitePasswordID = dbo.tWebsitePasswords.WebsitePasswordID INNER JOIN dbo.tWebsiteUsername ON dbo.tEntries.WebsiteUsernameID = dbo.tWebsiteUsername.WebsiteUsernameID WHERE(dbo.tEntries.UserID = " + userID + ")";

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
                        websiteDomain = String.Format("{0}", reader["WebsiteDomain"]);
                        websiteUsername = String.Format("{0}", reader["WebsiteUsername"]);
                        websitePassword = String.Format("{0}", reader["WebsitePassword"]);

                        CSV += websiteDomain + "," + websiteUsername + "," + websitePassword + "\n";

                    }

                    //if nothing is returned, then there must not be a match and the username / password does not exist
                    if (CSV == "")
                    {

                    }

                }

                //something went wrong
                catch (Exception e)
                {

                }

            }

            //everything went well
            return CSV;


        }
    }
}
