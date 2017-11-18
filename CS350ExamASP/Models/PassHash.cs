using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;

namespace CS350ExamASP.Models
{
    public class PassHash
    {

        private string strHash;
        private string strSalt;

        public const int SaltByteSize = 128;
        public const int HashByteSize = 1024;
        public const int Iterations = 3000;

        public string Hash { get { return strHash; } }
        public string Salt { get { return strSalt; } }

        public PassHash(SecureString password)
        {
            byte[] bytesSalt = new byte[SaltByteSize];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(bytesSalt);
            }
            strSalt = Convert.ToBase64String(bytesSalt);
            strHash = ComputeHash(strSalt, password);
        }

        public static string ComputeHash(string salt, SecureString password)
        {
            
        }

    }
}
