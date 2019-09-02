using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Entity.Sys
{
    /// <summary>
    /// 用户组与用户映射表
    /// </summary>
    public  class SysRole2UserEntity: Abp.Domain.Entities.Entity<string>
    {
        [Display(Name = "ID")]
        public override string Id { get; set; }
        [Display(Name = "菜单ID")]
        public  string ModuleId { get; set; }
        [Display(Name = "用户组")]
        public  string RoleId { get; set; }
    }
}
