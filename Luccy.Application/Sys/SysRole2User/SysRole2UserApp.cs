using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysRole2User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole2User
{
    public  class SysRole2UserApp:LuccyAppServiceBase,ISysRole2UserApp
    {
        private readonly ISysRole2UserRepository _sysRole2UserRepository;
        public SysRole2UserApp(ISysRole2UserRepository sysRole2UserRepository)
        {
            _sysRole2UserRepository = sysRole2UserRepository;
        }
 
        public Role2UserOutputDto GetRole2UserByUserId(Role2UserInputDto inputDto)
        {
            SysRole2UserEntity entity= _sysRole2UserRepository.GetAll().Where(b => b.SysUserId.Equals(inputDto.SysUserId)).FirstOrDefault();
            Role2UserDto role2user = AutoMapper.Mapper.Map<Role2UserDto>(entity);
            Role2UserOutputDto outputDto = new Role2UserOutputDto();
            outputDto.Role2UserDto = role2user;
            return outputDto;
        }
    }
}
