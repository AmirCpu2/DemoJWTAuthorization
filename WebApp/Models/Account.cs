using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AccountLogin
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
        public string Password { get; set; }

    }

    public class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول نام کاربری باید کمتر از 100 کارکتر باشد")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول رمزعبور باید کمتر از 100 کارکتر باشد")]
        public string Password { get; set; }

        public DateTime? RegisterDate { get; set; }

        public bool Active { get; set; }

        public int? FialedRepeat { get; set; }

        public DateTime? LastFialed { get; set; }

        public int? LoginCount { get; set; }

        public DateTime? LastLogin { get; set; }

        public long PersonID { get; set; }

        public DateTime? LastPasswordChanges { get; set; }

        public short InheritTypeID { get; set; }

        public virtual Person Person { get; set; }
    }
}
