using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Luccy.EntityFramework;

namespace Luccy
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(LuccyCoreModule))]
    public class LuccyDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<LuccyDbContext>(null);
        }
    }
}
