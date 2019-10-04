using System.Collections.Generic;
using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AutoMapper;
using Luccy.Entity.Sys;
using Luccy.Sys.SysModule.Dto;
using Luccy.Sys.SysRole.Dto;
using Luccy.Sys.SysRole2User.Dto;
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

                config.CreateMap<ModuleSumbitInputDto, SysModuleEntity>();
                config.CreateMap<SysModuleEntity, ModuleSumbitInputDto>();

                config.CreateMap<RoleSubmitInputDto, SysRoleEntity>();
                config.CreateMap<SysRoleEntity, RoleSubmitInputDto>();

                config.CreateMap<Role2UserSubmitInputDto, SysRole2UserEntity>();
                config.CreateMap<SysRole2UserEntity, Role2UserSubmitInputDto>();

                config.CreateMap<SysRole2UserEntity, Role2UserDto>();
                config.CreateMap<Role2UserDto, SysRole2UserEntity>();

            });
        }
    }
}
