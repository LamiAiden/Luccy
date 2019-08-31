using System;
using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using Luccy.Entity.Sys;
using Luccy.Mapping.Sys;

namespace Luccy.EntityFramework
{
    public class LuccyDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        public virtual IDbSet<SysUserEntity> SysUser { get; set; }
        public virtual IDbSet<SysModuleEntity> SysModule { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public LuccyDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in LuccyDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of LuccyDbContext since ABP automatically handles it.
         */
        public LuccyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public LuccyDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public LuccyDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            dynamic user = Activator.CreateInstance(typeof(SysUserMap));
            modelBuilder.Configurations.Add(user);
            dynamic Module = Activator.CreateInstance(typeof(SysModuleMap));
            modelBuilder.Configurations.Add(Module);

            base.OnModelCreating(modelBuilder);
        }


    }
}
