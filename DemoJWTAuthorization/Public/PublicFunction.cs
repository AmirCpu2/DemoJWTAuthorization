using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DemoJWTAuthorization
{
    public partial class PublicFunction
    {
        public static string GetHash(string data) => Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(data)));

        public static bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = $"http://demo.silkrood.ir",
                ValidAudience = $"http://demo.silkrood.ir",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("P@ssM0rdKeyAuthorization")) // The same key as the one that generate the token
            };
        }

        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, GetValidationParameters(), out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public static Stack<int> ArrayToStack(List<int> array)
        {
            var v = new Stack<int>();

            array.ForEach(q => v.Push(q));

            return v;
        }

        public static JwtSecurityToken DecodeToken(string token) {

            var handler = new JwtSecurityTokenHandler();
            return String.IsNullOrEmpty(token)? null : handler.ReadToken(token) as JwtSecurityToken;
        }
    }
}
