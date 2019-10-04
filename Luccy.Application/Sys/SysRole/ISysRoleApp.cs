using Abp.Application.Services;
using Luccy.CommonModel;
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
        void SubmitForm(RoleSubmitInputDto roleInputDto, UserInfo userinfo);
        void DeleteForm(RoleDeleteInputDto dto);
        RoleOutputDto GetForm(string keyword);
        RoleOutputDto GetList();
    }
}
