using System.Reflection;
using Abp.Modules;

namespace Luccy
{
    [DependsOn(typeof(LuccyCoreModule))]
    public class LuccyApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
