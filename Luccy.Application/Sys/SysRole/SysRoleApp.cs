using Luccy.CommonModel;
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

        public RoleOutputDto GetForm(string keyword)
        {
            SysRoleEntity userEntityList = _sysRoleRepository.Get(keyword);
            RoleDto RoleDtoList = AutoMapper.Mapper.Map<RoleDto>(userEntityList);
            RoleOutputDto outputDto = new RoleOutputDto();
            outputDto.RoleDtoSingle = RoleDtoList;
            return outputDto;
        }

        public void SubmitForm(RoleSubmitInputDto roleInputDto, UserInfo userinfo)
        {
            if (!string.IsNullOrEmpty(roleInputDto.Id)) //更新
            {
                SysRoleEntity entity = _sysRoleRepository.Get(roleInputDto.Id);
                entity.Name = roleInputDto.Name;
                entity.Description = roleInputDto.Description;
                entity.CreatePerson = userinfo.UserID;
                entity.CreateTime = DateTime.Now;
                _sysRoleRepository.Update(entity);
            }
            else
            {
                SysRoleEntity entity = AutoMapper.Mapper.Map<SysRoleEntity>(roleInputDto);
                entity.Id = Guid.NewGuid().ToString();
                entity.CreatePerson = userinfo.UserID;
                entity.CreateTime = DateTime.Now;
                _sysRoleRepository.Insert(entity);
            }
        }

        public void DeleteForm(RoleDeleteInputDto dto)
        {
            if (!string.IsNullOrEmpty(dto.Id))
                _sysRoleRepository.Delete(dto.Id);
        }

        public RoleOutputDto GetList()
        {
            var query = _sysRoleRepository.GetAll();
            RoleOutputDto output = new RoleOutputDto();
            List<RoleDto> roleDtoList = AutoMapper.Mapper.Map<List<RoleDto>>(query.ToList());
            output.RoleDtoList = roleDtoList;

            return output;
        }

    }
}
