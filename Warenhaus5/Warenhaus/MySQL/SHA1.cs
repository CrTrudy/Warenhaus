using System.Security.Cryptography;

namespace Warenhaus
{
    static class SHA1
    {
        public static string GetSha1(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            byte[] message = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hashValue = GetSha1(message);

            string hashString = string.Empty;
            foreach (byte x in hashValue)
            {
                hashString += string.Format("{0:x2}", x);
            }

            return hashString;

        }

        private static byte[] GetSha1(byte[] message)
        {
            SHA1Managed hashString = new SHA1Managed();
            return hashString.ComputeHash(message);
        }
    }
}