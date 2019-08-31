using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysUser.Dto
{
    public  class UserDto
    {
        public  string Id { get; set; }

        public string UserName { get; set; }
       
        public string TrueName { get; set; }
       
        public string PhoneNumber { get; set; }

        public string QQ { get; set; }

        public string EmailAddress { get; set; }

        public string CreatePerson { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
