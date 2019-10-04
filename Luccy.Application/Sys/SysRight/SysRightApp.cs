using Luccy.CommonModel;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysRight.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRight
{
    public  class SysRightApp:LuccyAppServiceBase,ISysRightApp
    {
        private ISysRightRepository _sysRightRepository;
        public SysRightApp(ISysRightRepository sysRightRepository)
        {
            _sysRightRepository = sysRightRepository;
        }
        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="dto"></param>
        public void SetRight(RightInputDto dto)
        {
            List<SysModuleOperateEntity> ListOperate = AutoMapper.Mapper.Map<List<SysModuleOperateEntity>>(dto.ModuleOperate);
                _sysRightRepository.SetRight(dto.RoleId, ListOperate);
        }


        public RightOutputDto GetAllRightByRoleIdAndMId(RightInputDto dto)
        {
            List<RightDto> outdto = new List<RightDto>();
            List<SysRightEntity> entity = _sysRightRepository.GetAllRightByRIdAndMid(dto.RoleId, dto.Mid);
            outdto = AutoMapper.Mapper.Map<List<RightDto>>(entity);
            RightOutputDto outputDto = new RightOutputDto();
            outputDto.RightList = outdto;
            return outputDto;
        }

       


    }
}
