
using System.Security.Cryptography;
using System.Text;

namespace MoneyControl.Infraestructure.Helpers.Hash
{
    public static class Hash256
    {
        public static string GetSHA256Hash(string Password)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(Password));
                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
    }
}
