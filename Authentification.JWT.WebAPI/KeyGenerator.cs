using System.Security.Cryptography;

namespace Authentification.JWT.WebAPI
{
    public class KeyGenerator
    {
        public static string GenerateSecretKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var secretKey = new byte[32]; // 256 bits = 32 octets
                rng.GetBytes(secretKey);
                return Convert.ToBase64String(secretKey); // Retourne la clé en Base64
            }
        }
    }
}
