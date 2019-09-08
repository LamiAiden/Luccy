using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysUser.Dto
{
    public  class UserInputDto
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }

        public string TrueName { get; set; }

        public string PhoneNumber { get; set; }

        public string QQ { get; set; }
    }
}
