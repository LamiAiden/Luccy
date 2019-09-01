using Abp.Application.Services;
using Luccy.Sys.SysRole.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole
{
    public interface ISysRoleApp: IApplicationService
    {
        RoleOutputDto GetRoleList(SearchRoleInputDto inputDto);
    }
}
