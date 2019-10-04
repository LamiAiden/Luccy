using Luccy.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModuleOperate.Dto
{
    public class ModuleOperateInputDto
    {
        public ModuleOperateInputDto() { }
        public ModuleOperateInputDto(Pagination page,string mid)
        {
            Pagination = page;
            Mid = mid;
        }
        [Required]
        public Pagination Pagination { get; set; }
        public string Mid { get; set; }
        public string RoleId { get; set; }
    }
}
