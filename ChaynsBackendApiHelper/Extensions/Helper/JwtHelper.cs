using System;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Chayns.Backend.Extensions.Helper
{
    public class JwtHelper
    {
        private const string RegexPattern = @"^[A-Za-z0-9-_=]+\.[A-Za-z0-9-_=]+\.?[A-Za-z0-9-_.+\/=]*$";

        /// <summary>
        /// Parses the token payload
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetPayload<T>(string token) where T : class
        {
            try
            {
                var parts = token.Split('.');

                var encodedBody = parts[1];

                encodedBody = encodedBody.Replace('-', '+'); // 62nd char of encoding
                encodedBody = encodedBody.Replace('_', '/'); // 63rd char of encoding
                switch (encodedBody.Length % 4) // Pad with trailing '='s
                {
                    case 0: break; // No pad chars in this case
                    case 2: encodedBody += "=="; break; // Two pad chars
                    case 3: encodedBody += "="; break; // One pad char
                    default: throw new Exception("Illegal base64url string!");
                }
                var converted = Convert.FromBase64String(encodedBody); // Standard base64 decoder
                var decodedBody = Encoding.UTF8.GetString(converted);

                return JsonConvert.DeserializeObject<T>(decodedBody);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tests if the given token matches the JWT regex
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsValid(string token)
        {
            return Regex.IsMatch(token, RegexPattern);
        }
    }
}
