using System.Reflection;
using Abp.Modules;

namespace Luccy
{
    public class LuccyCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
