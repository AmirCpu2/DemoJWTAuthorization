namespace DemoJWTAuthorization.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account",Schema = "SSO")]
    public partial class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
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
