﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FireDeptFeesTool.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FeeStatusesDBContext : DbContext
    {
        public FeeStatusesDBContext()
            : base("name=FeeStatusesDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FeeLogs> FeeLogs { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
    }
}
