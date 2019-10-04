using Abp.Application.Services;
using Luccy.Sys.SysRight.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRight
{
    public  interface  ISysRightApp : IApplicationService
    {
        void SetRight(RightInputDto dto);
        RightOutputDto GetAllRightByRoleIdAndMId(RightInputDto dto);
    }
}
