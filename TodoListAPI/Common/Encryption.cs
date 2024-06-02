using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace TodoListAPI.Common
{
    public static class Encryption
    {
        /// <summary>
        /// SHA256加密字串
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string SHA256Encrypt(this string strSource)
        {
            byte[] source = Encoding.Default.GetBytes(strSource);
            byte[] crypto = new SHA256CryptoServiceProvider().ComputeHash(source);
            string result = crypto.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));

            return result.ToUpper();
        }
    }
}
