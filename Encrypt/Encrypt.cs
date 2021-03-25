using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    public class Encrypt
    {
        public static String getMD5(String str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
