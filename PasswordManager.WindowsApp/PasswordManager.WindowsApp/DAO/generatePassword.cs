using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WindowsApp.DAO
{
    class generatePassword
    {


        //generates a random string consisting of 5 characters
        public string GenerateToken(int length)
        {
            RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
            byte[] tokenBuffer = new byte[length];
            cryptRNG.GetBytes(tokenBuffer);
            string randomString = Convert.ToBase64String(tokenBuffer);

            char[] characters = randomString.ToCharArray();
            List<char> finalChars = new List<char>();
            string password = "";
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {

                int index = rand.Next(0, characters.Length);


                finalChars.Add(characters[index]);
            }

            for (int i = 0; i < finalChars.Count; i++)
            {
                password += finalChars[i];
            }
            return password;

        }




    }
}
