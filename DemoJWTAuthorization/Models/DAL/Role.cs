namespace DemoJWTAuthorization.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Roles", Schema = "SSO")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            Roles1 = new HashSet<Role>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string TitleEn { get; set; }

        [Required]
        [StringLength(150)]
        public string TitleFa { get; set; }

        public int? ParentRoleID { get; set; }

        public bool IsPrivate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles1 { get; set; }

        public virtual Role Role1 { get; set; }
    }
}
