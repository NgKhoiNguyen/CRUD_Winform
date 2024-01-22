using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{
    public static class auth_helper
    {
        public static string generateToken()
        {
            return "";
        }
        public static bool validateToken()
        {
            return true;
        }

        public static string GenerateShortGuid()
        {
            using (var sha256 = System.Security.Cryptography.MD5.Create())
            {
                // Compute the hash of a new Guid
                var hashBytes = sha256.ComputeHash(Guid.NewGuid().ToByteArray());

                // Convert the hash to a base64-encoded string
                return Convert.ToBase64String(hashBytes);
            }
        }


    }

}
