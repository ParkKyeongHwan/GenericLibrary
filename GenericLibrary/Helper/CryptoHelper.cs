using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace GenericLibrary.Helper
{
    public static class CryptoHelper
    {
        public static string GetHash(this string text)
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