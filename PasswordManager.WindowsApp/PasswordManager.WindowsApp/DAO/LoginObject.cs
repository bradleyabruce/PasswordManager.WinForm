using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    public class LoginObject
    {
        public LoginObject(string userID, string userLoginEmail, string userLoginPassword)
        {
            UserID = userID;
            UserLoginEmail = userLoginEmail;
            UserLoginPassword = userLoginPassword;
        }

        public LoginObject()
        {
            UserID = null;
            UserLoginEmail = null;
            UserLoginPassword = null;
        }



        public string UserID { get; set; }
        public string UserLoginEmail { get; set; }
        public string UserLoginPassword { get; set; }

    }
}
