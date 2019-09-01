using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysUser.Dto
{
    public  class LoginInputDto
    {
        public  LoginInputDto(string name,string pwd)
        {
            Name = name;
            Pwd = pwd;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pwd { get; set; }
    }
}
