using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HartRevalidatieApplication.Helpers
{
    public static class HashFunction
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static string GetHash(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(encoding.GetBytes(password));

                return ByteToString(hashBytes);
            }
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }
    }
}
