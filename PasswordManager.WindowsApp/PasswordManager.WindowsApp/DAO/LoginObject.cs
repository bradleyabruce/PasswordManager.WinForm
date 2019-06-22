using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    public class LoginObject
    {
        #region Operators

        public LoginObject(string userID, string userLoginEmail, string userLoginPassword, bool status)
        {
            UserID = userID;
            UserLoginEmail = userLoginEmail;
            UserLoginPassword = userLoginPassword;
            Status = status;
        }

        public LoginObject()
        {
            UserID = null;
            UserLoginEmail = null;
            UserLoginPassword = null;
            Status = null;
        }

        #endregion

        #region Properties

        public string UserID { get; set; }
        public string UserLoginEmail { get; set; }
        public string UserLoginPassword { get; set; }
        public bool? Status { get; set; }

        #endregion
    }
}
