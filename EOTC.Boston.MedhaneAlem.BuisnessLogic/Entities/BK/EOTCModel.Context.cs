﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EFDBContext : DbContext
    {
        public EFDBContext()
            : base("name=EFDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<PasswordChange> PasswordChanges { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
    
        public virtual ObjectResult<Nullable<int>> spChangedPassword(Nullable<System.Guid> gUID, string password)
        {
            var gUIDParameter = gUID.HasValue ?
                new ObjectParameter("GUID", gUID) :
                new ObjectParameter("GUID", typeof(System.Guid));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spChangedPassword", gUIDParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spIsPasswordChangeLinkValid(Nullable<System.Guid> gUID)
        {
            var gUIDParameter = gUID.HasValue ?
                new ObjectParameter("GUID", gUID) :
                new ObjectParameter("GUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spIsPasswordChangeLinkValid", gUIDParameter);
        }
    
        public virtual ObjectResult<spResetPassword_Result> spResetPassword(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spResetPassword_Result>("spResetPassword", userNameParameter);
        }
    }
}