using Abp.Domain.Repositories;
using Luccy.Core.CommonModel;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysUser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Luccy.Sys.SysUser
{
    public  class SysUserApp : LuccyAppServiceBase, ISysUserApp
    {
        private readonly ISysUserRepository _sysUserRepository;
        public SysUserApp(ISysUserRepository sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }

        public UserListOutputDto GetUserList(Pagination pagination, string keyword)
        {
            List<SysUserEntity> userEntityList= _sysUserRepository.GetUserListByPage(pagination, keyword);
            List<UserDto> userDtoList= AutoMapper.Mapper.Map<List<UserDto>>(userEntityList);
            UserListOutputDto outputDto = new UserListOutputDto();
            outputDto.UserDtoList = userDtoList;
            return outputDto;
        }




        /// <summary>
        /// 根据名称和密码获取用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UserDto CheckLogin(string name ,string pwd)
        {
            SysUserEntity entity= _sysUserRepository.GetAll().Where(b=>b.UserName.Equals(name)&&b.Password.Equals(pwd)).FirstOrDefault();
            UserDto dto = AutoMapper.Mapper.Map<UserDto>(entity);
            return dto;
        }


    }
}
