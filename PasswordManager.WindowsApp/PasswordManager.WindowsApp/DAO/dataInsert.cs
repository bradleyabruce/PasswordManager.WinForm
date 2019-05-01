using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    class dataInsert
    {

        dataLogin dl = new dataLogin();


        
        public int insertWebsiteDomain(string domain) {

            string query = "INSERT INTO [dbo].[tWebsiteDomains] (WebsiteDomain) VALUES (@WebsiteDomain); SELECT SCOPE_IDENTITY()";
            int returnedID = 0;

            using (SqlConnection conn = new SqlConnection(dl.getConnectionString()))
            {


                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@WebsiteDomain", domain);

                    conn.Open();

                    returnedID = Convert.ToInt32(command.ExecuteScalar());

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();

                    return returnedID;

                }
            }

        }




        public int insertWebsiteUsername(string username)
        {


            string query = "INSERT INTO [dbo].[tWebsiteUsername] (WebsiteUsername) VALUES (@WebsiteUsername); SELECT SCOPE_IDENTITY()";
            int returnedID = 0;

            using (SqlConnection conn = new SqlConnection(dl.getConnectionString()))
            {


                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@WebsiteUsername", username);

                    conn.Open();

                    returnedID = Convert.ToInt32(command.ExecuteScalar());

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();

                    return returnedID;

                }
            }
        }





        public int insertWebsitePassword(string password)
        {


            string query = "INSERT INTO [dbo].[tWebsitePasswords] (WebsitePassword) VALUES (@WebsitePassword); SELECT SCOPE_IDENTITY()";
            int returnedID = 0;

            using (SqlConnection conn = new SqlConnection(dl.getConnectionString()))
            {


                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@WebsitePassword", password);

                    conn.Open();

                    returnedID = Convert.ToInt32(command.ExecuteScalar());

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();

                    return returnedID;

                }
            }
        }





        public int insertEntry(int userID, int websiteDomainID, int websiteUsernameID, int websitePasswordID, int categoryID)
        {


            string query = "INSERT INTO [dbo].[tEntries] (UserID, WebsiteDomainID, WebsiteUsernameID, WebsitePasswordID, CategoryID) VALUES (@userID, @websiteDomainID, @websiteUsernameID, @websitePasswordID, @categoryID); SELECT SCOPE_IDENTITY()";

            int returnedID = 0;

            using (SqlConnection conn = new SqlConnection(dl.getConnectionString()))
            {


                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@websiteDomainID", websiteDomainID);
                    command.Parameters.AddWithValue("@websiteUsernameID", websiteUsernameID);
                    command.Parameters.AddWithValue("@websitePasswordID", websitePasswordID);
                    command.Parameters.AddWithValue("@categoryID", categoryID);

                    conn.Open();

                    returnedID = Convert.ToInt32(command.ExecuteScalar());

                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();

                    return returnedID;

                }
            }
        }



    }

}
