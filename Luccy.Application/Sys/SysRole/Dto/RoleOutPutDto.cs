using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole.Dto
{
    public class RoleOutputDto
    {
       public  List<RoleDto> RoleDtoList { get; set; }

       public RoleDto RoleDtoSingle { get; set; }
    }
}
