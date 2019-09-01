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
        public SysModuleOperateApp(ISysModuleOperateRepository sysModuleOperateRepository)
        {
            _sysModuleOperateRepository = sysModuleOperateRepository;
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

        ///// <summary>
        ///// 根据模块ID获取操作权限
        ///// </summary>
        ///// <param name="inputDto"></param>
        ///// <returns></returns>
        //public ModuleOperateOutputDto GetListByPage(ModuleOperateInputDto inputDto)
        //{
        //    List<SysModuleOperateEntity> ModuleOperateEntityList;
        //    ModuleOperateEntityList = _sysModuleOperateRepository.GetModuleOperateListByPage(inputDto.Pagination,inputDto.Mid);
        //    List<ModuleOperateDto> OperateDtoList = AutoMapper.Mapper.Map<List<ModuleOperateDto>>(ModuleOperateEntityList);
        //    ModuleOperateOutputDto outputDto = new ModuleOperateOutputDto();
        //    outputDto.ModuleOperateList = OperateDtoList;
        //    return outputDto;
        //}
    }
}
