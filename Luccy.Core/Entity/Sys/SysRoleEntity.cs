using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Entity.Sys
{
    public  class SysRoleEntity: Abp.Domain.Entities.Entity<string>
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "角色名称")]
        public string Name { get; set; }

        [Display(Name = "说明")]
        public string Description { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "创建人")]
        public string CreatePerson { get; set; }
    }
}
