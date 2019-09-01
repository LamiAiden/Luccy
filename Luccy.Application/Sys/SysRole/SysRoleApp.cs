using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysRole.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole
{
    public  class SysRoleApp: LuccyAppServiceBase, ISysRoleApp
    {
        private readonly ISysRoleRepository _sysRoleRepository;
        public SysRoleApp(ISysRoleRepository sysRoleRepository)
        {
            _sysRoleRepository = sysRoleRepository;
        }

        public RoleOutputDto GetRoleList(SearchRoleInputDto inputDto)
        {
            List<SysRoleEntity> roleEntityList = _sysRoleRepository.GetRoleListByPage(inputDto.Page, inputDto.Name);
            List<RoleDto> roleDtoList = AutoMapper.Mapper.Map<List<RoleDto>>(roleEntityList);
            RoleOutputDto outputDto = new RoleOutputDto();
            outputDto.RoleDtoList = roleDtoList;
            return outputDto;
        }


    }
}
