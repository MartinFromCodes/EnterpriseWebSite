using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EnterpriseWebSite.Security
{
    public class HashUtility
    {


        //Methods
        public static string GetMd5Hash(string plainMessage)
        {
            byte[] buffer = MD5.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainMessage));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            return builder.ToString();
        }


        public static string GetSHA256Hash(string plainMessage)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainMessage);
            using (HashAlgorithm algorithm = new SHA256Managed())
            {
                algorithm.TransformFinalBlock(bytes, 0, bytes.Length);
                return Convert.ToBase64String(algorithm.Hash);

            }


        }

        public static string GEtSHA512Hash(string plainMessage)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainMessage);
            using (HashAlgorithm algorithm = new SHA512Managed())
            {
                algorithm.TransformFinalBlock(bytes, 0, bytes.Length);
                return Convert.ToBase64String(algorithm.Hash);

            }
        }


    }
}
