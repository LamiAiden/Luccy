using Abp.Application.Services;
using Luccy.CommonModel;
using Luccy.Sys.SysModuleOperate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate
{
    public  interface ISysModuleOperateApp: IApplicationService
    {
        ModuleOperateOutputDto GetList(ModuleOperateInputDto inputDto);
        ModuleOperateOutputDto GetForm(string keyword);
        void SubmitForm(ModuleOperateSumbitInputDto moduleOperateInputDto, UserInfo userinfo);
        void DeleteForm(ModuleOperateDeleteInputDto dto);

        ModuleOperateOutputDto GetPermissionByUserIdAndUrl(ModuleOperateSearchInputDto dto);
    }
}
