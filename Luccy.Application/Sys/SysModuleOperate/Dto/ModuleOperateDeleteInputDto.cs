using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate.Dto
{
    public  class ModuleOperateDeleteInputDto
    {
        [Required]
        public string Id { get; set; }
    }
}
