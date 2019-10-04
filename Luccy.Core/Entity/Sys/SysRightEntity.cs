using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Entity.Sys
{
    /// <summary>
    /// 用户组菜单映射表
    /// </summary>
    public class SysRightEntity : Abp.Domain.Entities.Entity<string>
    {
        [Display(Name = "ID")]
        public override string Id { get; set; }
        [Display(Name = "ModuleOperateId")]
        public  string ModuleOperateId { get; set; }
        [Display(Name = "RoleId")]
        public  string RoleId { get; set; }
        [Display(Name = "IsValid")]
        public bool IsValid { get; set; }
    }
}
