using System.Collections.Generic;
using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AutoMapper;
using Luccy.Entity.Sys;
using Luccy.Sys.SysModule.Dto;
using Luccy.Sys.SysUser.Dto;

namespace Luccy
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(LuccyCoreModule))]
    public class LuccyApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<SysModuleEntity, ModuleDto>();
                config.CreateMap<ModuleDto, SysModuleEntity>();

                config.CreateMap<SysUserEntity,UserDto>();
                config.CreateMap<UserInputDto, SysUserEntity>();
                

            });
        }
    }
}
