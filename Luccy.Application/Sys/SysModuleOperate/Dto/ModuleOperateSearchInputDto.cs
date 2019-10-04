using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate.Dto
{
    public  class ModuleOperateSearchInputDto
    {
        [Required]
        public  string UserId { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
