using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoJWTAuthorization.Models.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountLog> AccountLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Accounts)
                    .WithOne(e => e.Person).IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.AccountLogs)
                    .WithOne(e => e.Account)
                        .HasForeignKey(e => e.AccountId);

            modelBuilder.Entity<Person>().ToTable("Person", "Profile");
            modelBuilder.Entity<Account>().ToTable("Account", "SSO");
            modelBuilder.Entity<AccountLog>().ToTable("AccountLog", "SSO");
        }

    }
}
