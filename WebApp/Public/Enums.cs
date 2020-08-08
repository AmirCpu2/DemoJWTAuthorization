using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Public
{
    public class Enums
    {
        /// <summary>
        /// متدهای ارسال
        /// </summary>
        public enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        /// <summary>
        /// نوع احراز هویت
        /// </summary>
        public enum AuthenticationType
        {
            Basic,
            NTLM,
            Bearer
        }

        /// <summary>
        /// تکنیک احراز هویت
        /// </summary>
        public enum AutheticationTechnique
        {
            RollYourOwn,
            NetworkCredential
        }

        /// <summary>
        /// وضعیت درخواست
        /// </summary>
        public enum StatusRequest
        {
            /// <summary>ناموفق</summary>
            Failed      = 0,
            /// <summary>موفق</summary>
            Successful  = 2
        }

    }
}
