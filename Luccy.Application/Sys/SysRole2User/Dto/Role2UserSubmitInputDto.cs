using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole2User.Dto
{
    public  class Role2UserSubmitInputDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
