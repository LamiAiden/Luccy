using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace Luccy
{
    [DependsOn(typeof(AbpWebApiModule), typeof(LuccyApplicationModule))]
    public class LuccyWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(LuccyApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
