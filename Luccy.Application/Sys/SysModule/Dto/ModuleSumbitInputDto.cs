using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModule.Dto
{
    public  class ModuleSumbitInputDto
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string EnglishName { get; set; }
        [Required]
        public string ParentId { get; set; }
        [Required]
        public string Url { get; set; }
        public string Iconic { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public bool IsLast { get; set; }

    }
}
