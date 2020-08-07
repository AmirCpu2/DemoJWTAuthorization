using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoJWTAuthorization
{
    public partial class PublicFunction
    {
        public static string GetHash(string data) => Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(data)));
    }
}
