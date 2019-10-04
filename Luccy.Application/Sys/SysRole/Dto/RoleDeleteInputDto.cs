using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole.Dto
{
    public  class RoleDeleteInputDto
    {
        [Required]
        public string Id { get; set; }
    }
}
