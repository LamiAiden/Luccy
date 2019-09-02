using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Entity.Sys
{
    /// <summary>
    /// 权限组和按钮权限映射表
    /// </summary>
    public class SysRightOperateEntity : Abp.Domain.Entities.Entity<string>
    {
        [Display(Name = "ID")]
        public override string Id { get; set; }
        [Display(Name = "Right表主键")]
        public string RightId { get; set; }
        [Display(Name = "KeyCode")]
        public string KeyCode { get; set; }
        [Display(Name = "是否验证")]
        public bool IsValid { get; set; }
    }
}
