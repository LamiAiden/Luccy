using Abp.Application.Services;
using Luccy.Sys.SysRole2User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole2User
{
    public interface ISysRole2UserApp:IApplicationService
    {
        Role2UserOutputDto GetRole2UserByUserId(Role2UserInputDto inputDto);
    }
}
