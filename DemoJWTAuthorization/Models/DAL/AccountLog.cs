using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoJWTAuthorization.Models.DAL
{
    [Table("AccountLog", Schema = "Profile")]
    public partial class AccountLog
    {
        public AccountLog()
        {
            Account = new Account();
        }

        public int Id { get; set; }

        public int AccountId { get; set; }

        public DateTime DateTime { get; set; }

        public bool? Logined { get; set; }

        public virtual Account Account { get; set; }
    }
}
