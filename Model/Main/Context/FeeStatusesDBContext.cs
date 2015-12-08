using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FireDeptFeesTool.Model.Main
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class FeeStatusesDBContext : DbContext
    {
        public FeeStatusesDBContext()
            : base("name=FeeStatusesDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<FeeLogs> FeeLogs { get; set; }
        public DbSet<Member> Member { get; set; }
    }
}
