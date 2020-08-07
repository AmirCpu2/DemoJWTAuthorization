using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoJWTAuthorization.Models.VM
{
    public class AccountModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "نام کاربری خود را وارد کنید")]
        public string UserName { get; set; }

        /// <summary>
        /// PassWord
        /// </summary>
        [Required(ErrorMessage = "رمز عبور خود را وارد کنید")]
        public string PassWord { get; set; }

    }
}
