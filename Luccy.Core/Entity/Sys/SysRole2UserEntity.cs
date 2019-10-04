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
        [Display(Name = "用户ID")]
        public  string SysUserId { get; set; }
        [Display(Name = "用户组")]
        public  string SysRoleId { get; set; }
    }
}
