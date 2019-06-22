using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    class PasswordObject
    {
        #region Operators

        public PasswordObject(string status, string entryID, string websiteDomain, string websiteUsername, string websitePassword, string categoryID)
        {
            Status = status;
            EntryID = entryID;
            WebsiteDomain = websiteDomain;
            WebsiteUsername = websiteUsername;
            WebsitePassword = websitePassword;
            CategoryID = categoryID;
        }
                     
        public PasswordObject()
        {
            Status = null;
            EntryID = null;
            WebsiteDomain = null;
            WebsiteUsername = null;
            WebsitePassword = null;
            CategoryID = null;
        }

        #endregion

        #region Properties

        public string Status { get; set; }
        public string EntryID { get; set; }
        public string WebsiteDomain { get; set; }
        public string WebsiteUsername { get; set; }
        public string WebsitePassword { get; set; }
        public string CategoryID { get; set; }

        #endregion
    }
}
