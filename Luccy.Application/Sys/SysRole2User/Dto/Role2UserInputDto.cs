using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole2User.Dto
{
    public  class Role2UserInputDto
    {
        [Required]
        public string SysUserId { get; set; }
    }
}
