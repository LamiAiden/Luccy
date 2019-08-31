using AutoMapper;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysModule.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModule
{
    public class SysModuleApp: LuccyAppServiceBase,ISysModuleApp
    {
        private ISysModuleRepository _sysModuleRepository;
        public SysModuleApp(ISysModuleRepository sysModuleRepository)
        {
            _sysModuleRepository = sysModuleRepository;
        }
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public ModuleListOutputDto GetModuleList()
        {
            List<SysModuleEntity> entityList = _sysModuleRepository.GetAllList();
            ModuleDto dd= Mapper.Map<ModuleDto>(entityList[0]);
            List<ModuleDto> dtoList = Mapper.Map<List<ModuleDto>>(entityList);
            ModuleListOutputDto output = new ModuleListOutputDto();
            output.ModuleDtoList = dtoList;
            return output;
        }
    }
}
