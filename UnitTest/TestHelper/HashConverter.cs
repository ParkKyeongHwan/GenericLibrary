using System;
using System.Security.Cryptography;
using System.Text;

namespace UnitTest.TestHelper
{
    public static class HashConverter
    {
        internal static string GetHash(this string text)
        {
            byte[] bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in bytes)
            {
                stringBuilder.Append(b);
            }

            return stringBuilder.ToString();
        }
    }
}
