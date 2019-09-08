using Abp.Application.Services;
using Luccy.CommonModel;
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
        UserOutputDto GetUserList(Pagination pagination, string keyword);
        void SubmitForm(UserInputDto userInputDto, UserInfo userinfo);
        UserOutputDto GetForm(string keyword);
        void DeleteForm(UserDeleteInputDto dto);
    }
}
