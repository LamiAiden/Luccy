using Abp.Application.Services;
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
    }
}
