using Abp.Domain.Repositories;
using Luccy.CommonModel;
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
    public class SysUserApp : LuccyAppServiceBase, ISysUserApp
    {
        private readonly ISysUserRepository _sysUserRepository;
        public SysUserApp(ISysUserRepository sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }
        /// <summary>
        /// 分页查询用户列表
        /// </summary>
        /// <param name="pagination">分页类</param>
        /// <param name="keyword">查询关键字</param>
        /// <returns></returns>
        public UserOutputDto GetUserList(Pagination pagination, string keyword)
        {
            List<SysUserEntity> userEntityList = _sysUserRepository.GetUserListByPage(pagination, keyword);
            List<UserDto> userDtoList = AutoMapper.Mapper.Map<List<UserDto>>(userEntityList);
            UserOutputDto outputDto = new UserOutputDto();
            outputDto.UserDtoList = userDtoList;
            return outputDto;
        }

        public UserOutputDto GetForm(string keyword)
        {
            SysUserEntity userEntityList = _sysUserRepository.Get(keyword);
            UserDto userDtoList = AutoMapper.Mapper.Map<UserDto>(userEntityList);
            UserOutputDto outputDto = new UserOutputDto();
            outputDto.UserDtoSingle = userDtoList;
            return outputDto;
        }

        public void SubmitForm(UserInputDto userInputDto, UserInfo userinfo)
        {
            SysUserEntity entity = AutoMapper.Mapper.Map<SysUserEntity>(userInputDto);
            if (!string.IsNullOrEmpty(userInputDto.Id)) //更新
            {
                //SysUserEntity entity = _sysUserRepository.Get(userInputDto.Id);
                //entity.UserName = userInputDto.UserName;
                //entity.TrueName = userInputDto.TrueName;
                //entity.QQ = userInputDto.QQ;
                //entity.PhoneNumber = userInputDto.PhoneNumber;
                _sysUserRepository.Update(entity);
            }
            else
            {
                // SysUserEntity entity = AutoMapper.Mapper.Map<SysUserEntity>(userInputDto);
                entity.Id = Guid.NewGuid().ToString();
                entity.Password = Common.Utils.Md5.GetMD5("123456");
                entity.CreatePerson = userinfo.UserID;
                entity.CreateTime = DateTime.Now;
            }
        }

        public void DeleteForm(UserDeleteInputDto dto)
        {
            if(!string.IsNullOrEmpty(dto.Id))
            _sysUserRepository.Delete(dto.Id);
        }



        /// <summary>
        /// 根据名称和密码获取用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UserDto CheckLogin(LoginInputDto inputDto)
        {
            SysUserEntity entity = _sysUserRepository.GetAll().Where(b => b.UserName.Equals(inputDto.Name) && b.Password.Equals(inputDto.Pwd)).FirstOrDefault();
            UserDto dto = AutoMapper.Mapper.Map<UserDto>(entity);
            return dto;
        }


    }
}
