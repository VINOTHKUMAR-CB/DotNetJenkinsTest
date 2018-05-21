using System;
using System.Security.Cryptography;
using System.Text;

namespace HoneyWellAPITests.Helpers
{
    public class Encryption
    {
        public static string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
