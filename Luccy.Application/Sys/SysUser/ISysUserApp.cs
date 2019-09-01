using Abp.Application.Services;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysUser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysUser
{
    public interface ISysUserApp : IApplicationService
    {
        UserDto CheckLogin(LoginInputDto inputDto);
        UserListOutputDto GetUserList(Pagination pagination, string keyword);
    }
}
