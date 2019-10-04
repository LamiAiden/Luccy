using Luccy.Sys.SysModuleOperate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRight.Dto
{
   public  class RightInputDto
    { 
        public List<ModuleOperateDto> ModuleOperate { get; set; }
        [Required]
        public string RoleId { get; set; }
        public string Mid { get; set; }
    }
}
