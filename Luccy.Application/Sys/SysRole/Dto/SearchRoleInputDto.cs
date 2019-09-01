using Luccy.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysRole.Dto
{
    public  class SearchRoleInputDto
    {
        public SearchRoleInputDto(Pagination pa,string name)
        {
            Page = pa;
            Name = name;
        }
        public Pagination Page{ get; set; }
        public string Name { get; set; }
    }
}
