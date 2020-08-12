using DemoJWTAuthorization.Models.DAL;
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
        [StringLength(100,ErrorMessage ="طول نام کاربری باید کمتر از 100 کارکتر باشد")]
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
    #endregion

    public static partial class Mapper 
    {
        public static Account Map(MM.Account entity) 
        {
            if (entity == null)
                return null;

            return new Account {
                Id = entity.Id,
                UserName = entity.UserName,
                Password = entity.Password,
                Active = entity.Active,
                LastPasswordChanges = entity.LastPasswordChanges,
                Person = entity.Person,
                PersonID = entity.PersonID,
                RegisterDate = entity.RegisterDate
            };
        }

        public static MM.Account Map(Account entity)
        {
            if (entity == null)
                return null;

            return new MM.Account
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Password = entity.Password,
                Active = entity.Active,
                LastPasswordChanges = entity.LastPasswordChanges,
                Person = entity.Person,
                PersonID = entity.PersonID,
                RegisterDate = entity.RegisterDate
            };
        }

        public static MM.Account Map([Required]AccountLogin entity) => new MM.Account() { UserName=entity.UserName, Password = entity.Password };
    }

    internal class AccountRepository
    {
        internal AccountRepository(Context context)
        {
            DB = context;
        }

        private Context DB;

        internal Account Add(Account account)
        {
            if (account == null)
                return null;

            account.Password = PublicFunction.GetHash(account.Password);

            var MMAcount = Mapper.Map(account);

            DB.Accounts.Add(MMAcount);

            DB.SaveChanges();

            return Mapper.Map(DB.Accounts.Where(q => q.UserName == account.UserName).FirstOrDefault());
        }

        internal Account Edit(Account account)
        {
            if (account?.Id == null)
                return null;

            var MMAcount = Mapper.Map(account);

            DB.Accounts.Update(MMAcount);

            DB.SaveChanges();

            return Mapper.Map(DB.Accounts.Where(q => q.UserName == account.UserName).FirstOrDefault());
        }

        internal Account GetByUserName(string userName)
        {
            if (userName == null)
                return null;

            return Mapper.Map(DB.Accounts.Where(q => q.UserName.ToLower() == userName.ToLower()).FirstOrDefault());
        }

        internal Account GetById(int Id)
        {
            var account = DB.Accounts.Where(q => q.Id == Id).FirstOrDefault();
            return Mapper.Map(account);
        }

        internal IEnumerable<Account> GetAll() => DB.Accounts.ToList().Select(Mapper.Map);

        internal IQueryable<MM.Account> QueryableGetAll() => DB.Set<MM.Account>();

        internal bool Remove(int id)
        {
            var entity = DB.Accounts.Where(q => q.Id.Equals(id)).FirstOrDefault();

            if (entity == null)
                return false;

            entity.Active = false;

            Add(Mapper.Map(entity));

            return true;
        }

        internal Person GetPersonById(int id)
        {
            return DB.People.Where(q => q.Id.Equals(DB.Accounts.Where(q => q.Id == id).FirstOrDefault().PersonID)).FirstOrDefault();
        }
    }
}
