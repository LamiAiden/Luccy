using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate.Dto
{
    public  class ModuleOperateSumbitInputDto
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string KeyCode { get; set; }
        [Required]
        public string ModuleId { get; set; }
        [Required]
        public bool IsValid { get; set; }
        public int Sort { get; set; }
    }
}
