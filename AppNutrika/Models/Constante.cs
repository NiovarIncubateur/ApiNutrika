using System.Security.Cryptography;
using System.Text;

namespace AppNutrika.Models
{
    public class Constante
    {

        public static string GenerationPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }


        public static String hashPassword(String password)
        {
            Encoding enc = Encoding.UTF8;
            Byte[] rawMessage = enc.GetBytes(password);

            SHA1 sha1 = new SHA1CryptoServiceProvider();

            Byte[] result = sha1.ComputeHash(rawMessage);
            string mac = Convert.ToBase64String(result);

            //split the string in 2 and return the first half
            mac = mac.Substring(0, mac.Length / 2);

            return mac;
        }
    }
}
