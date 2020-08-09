using DemoJWTAuthorization.Models.DAL;
using DemoJWTAuthorization.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MM = DemoJWTAuthorization.Models.DAL;

namespace DemoJWTAuthorization.Models.VM
{
    #region ViewModels

    public class AccountLog
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public DateTime DateTime { get; set; }

        public bool? Logined { get; set; }

        public virtual Account Account { get; set; }
    }
    #endregion

    public static partial class Mapper
    {
        public static AccountLog Map(MM.AccountLog entity)
        {
            return new AccountLog
            {
                Id = entity.Id,
                Account = Mapper.Map(entity.Account),
                AccountId = entity.AccountId,
                DateTime = entity.DateTime,
                Logined = entity.Logined
            };
        }

        public static MM.AccountLog Map(AccountLog entity)
        {
            return new MM.AccountLog
            {
                Id = entity.Id,
                Account = Mapper.Map(entity.Account),
                AccountId = entity.AccountId,
                DateTime = entity.DateTime,
                Logined = entity.Logined
            };
        }

    }

    internal class AccountLogRepository
    {
        internal AccountLogRepository(Context context)
        {
            DB = context;
        }

        private Context DB;

        internal bool Add(AccountLog accountLog)
        {
            if (accountLog == null)
                return false;

            var MMAcountLog = Mapper.Map(accountLog);

            DB.AccountLogs.Add(MMAcountLog);

            DB.SaveChanges();

            return true;
        }

        internal void AddForse(int id,Enums.AccountLogState accountLogState)
        {

            DB.AccountLogs.Add(new MM.AccountLog {
                AccountId = id,
                Account = DB.Accounts.FirstOrDefault(q=>q.Id.Equals(id)),
                DateTime = DateTime.Now,
                Logined = ((int)accountLogState).Equals(1) ? true : false
            });

            DB.SaveChanges();
        }

        internal AccountLog Get(int Id)
        {
            return Mapper.Map(DB.AccountLogs.FirstOrDefault(q => q.Id == Id));
        }

        internal IEnumerable<AccountLog> GetAll() => DB.AccountLogs.ToList().Select(Mapper.Map);

        internal IQueryable<MM.AccountLog> QueryableGetAll() => DB.Set<MM.AccountLog>();

    }
}
