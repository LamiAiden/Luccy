using Abp.Application.Services;
using Luccy.Sys.SysModule.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModule
{
    public  interface ISysModuleApp: IApplicationService
    {
        ModuleOutputDto GetTreeGridList();
        ModuleOutputDto GetModuleList();
        ModuleOutputDto GetTreeViewList();
    }
}
