using Luccy.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate.Dto
{
    public  class ModuleOperateOutputDto
    {
        public  List<ModuleOperateDto> ModuleOperateList { get; set; }
        public ModuleOperateDto ModuleOperateDtoSingle { get; set; }

        public List<PermModel> PermList { get; set; }
    }
}
