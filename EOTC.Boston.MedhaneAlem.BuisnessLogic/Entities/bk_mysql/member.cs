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
    
    public partial class member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public member()
        {
            this.userlogins = new HashSet<userlogin>();
        }
    
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public int RoleID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual role role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userlogin> userlogins { get; set; }
    }
}