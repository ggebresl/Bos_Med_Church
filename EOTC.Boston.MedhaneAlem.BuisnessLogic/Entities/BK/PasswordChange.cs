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
    
    public partial class PasswordChange
    {
        public System.Guid ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> PasswordChangeDate { get; set; }
    
        public virtual UserLogin UserLogin { get; set; }
    }
}