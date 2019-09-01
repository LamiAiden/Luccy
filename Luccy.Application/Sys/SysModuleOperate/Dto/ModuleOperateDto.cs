using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate.Dto
{
    public  class ModuleOperateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string KeyCode { get; set; }
        public string ModuleId { get; set; }
        public bool IsValid { get; set; }
        public int Sort { get; set; }
    }
}
