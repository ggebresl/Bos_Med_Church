//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EOTC.Boston.MedhaneAlem.BuisnessLogic.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Payments = new HashSet<Payment>();
            this.UserLogins = new HashSet<UserLogin>();
            this.RoleID = 5;  //set default values;
        }

        //This field is auto generated by sql server so hide it during the Edit/Create
        [HiddenInput(DisplayValue = false)]
        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string State { get; set; }
        [Required]
        [StringLength(12)]
        public string Zip { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Fax { get; set; }
        [StringLength(30)]
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Column(TypeName = "date")]
        public System.DateTime MemberCreateDate { get; set; }
       [Column(TypeName = "date")]
        public System.DateTime MemberUpdateDate { get; set; }
        [Required]
        [StringLength(30)]
        public string MemberStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
