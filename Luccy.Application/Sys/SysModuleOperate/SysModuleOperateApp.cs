using Luccy.CommonModel;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysModuleOperate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate
{
    public  class SysModuleOperateApp : LuccyAppServiceBase, ISysModuleOperateApp
    {
        private ISysModuleOperateRepository _sysModuleOperateRepository;
        private ISysRole2UserRepository _sysRole2UserRepository;
        public SysModuleOperateApp(ISysModuleOperateRepository sysModuleOperateRepository, ISysRole2UserRepository sysRole2UserRepository)
        {
            _sysModuleOperateRepository = sysModuleOperateRepository;
            _sysRole2UserRepository = sysRole2UserRepository;
    }

        /// <summary>
        /// 根据模块ID获取操作权限
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public ModuleOperateOutputDto GetList(ModuleOperateInputDto inputDto)
        {
            List<SysModuleOperateEntity> ModuleOperateEntityList;
            ModuleOperateEntityList = _sysModuleOperateRepository.GetAll().Where(b => b.ModuleId.Equals(inputDto.Mid)).ToList();


            List<ModuleOperateDto> OperateDtoList = AutoMapper.Mapper.Map<List<ModuleOperateDto>>(ModuleOperateEntityList);
            ModuleOperateOutputDto outputDto = new ModuleOperateOutputDto();
            outputDto.ModuleOperateList = OperateDtoList;
            return outputDto;
        }


        /// <summary>
        /// 根据ID获取菜单详情
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ModuleOperateOutputDto GetForm(string keyword)
        {
            SysModuleOperateEntity userEntityList = _sysModuleOperateRepository.Get(keyword);
            ModuleOperateDto moduleOperateDtoList = AutoMapper.Mapper.Map<ModuleOperateDto>(userEntityList);
            ModuleOperateOutputDto outputDto = new ModuleOperateOutputDto();
            outputDto.ModuleOperateDtoSingle = moduleOperateDtoList;
            return outputDto;
        }
        /// <summary>
        /// 提交菜单更改
        /// </summary>
        /// <param name="userInputDto"></param>
        /// <param name="userinfo"></param>
        public void SubmitForm(ModuleOperateSumbitInputDto moduleOperateInputDto, UserInfo userinfo)
        {
            if (!string.IsNullOrEmpty(moduleOperateInputDto.Id)) //更新
            {
                SysModuleOperateEntity entity = _sysModuleOperateRepository.Get(moduleOperateInputDto.Id);
                entity.Name = moduleOperateInputDto.Name;
                entity.KeyCode= moduleOperateInputDto.KeyCode;
               // entity.ModuleId = moduleOperateInputDto.ModuleId;
                entity.Sort = moduleOperateInputDto.Sort;
                entity.IsValid = moduleOperateInputDto.IsValid;
                _sysModuleOperateRepository.Update(entity);
            }
            else
            {
                SysModuleOperateEntity entity = AutoMapper.Mapper.Map<SysModuleOperateEntity>(moduleOperateInputDto);
                entity.Id = Guid.NewGuid().ToString();
                _sysModuleOperateRepository.Insert(entity);
            }
        }
        /// <summary>
        /// 删除操作码
        /// </summary>
        /// <param name="dto"></param>
        public void DeleteForm(ModuleOperateDeleteInputDto dto)
        {
            if (!string.IsNullOrEmpty(dto.Id))
            {
                _sysModuleOperateRepository.Delete(dto.Id);
            }
        }
        public ModuleOperateOutputDto GetPermissionByUserIdAndUrl(ModuleOperateSearchInputDto dto)
        {
            List<PermModel> permModelList = _sysModuleOperateRepository.GetPermissionByUserIdAndUrl(dto.UserId, dto.Url);
            ModuleOperateOutputDto outputDto = new ModuleOperateOutputDto();
            outputDto.PermList = permModelList;
            return outputDto;
        }
    }
}
