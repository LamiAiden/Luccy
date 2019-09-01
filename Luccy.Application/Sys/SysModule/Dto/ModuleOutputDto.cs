using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModule.Dto
{
    public  class ModuleOutputDto
    {
        public List<ModuleDto> ModuleDtoList { get; set; }
        public string TreeGridJson { get; set; }
        public string TreeViewJson { get; set; }
    }
}
