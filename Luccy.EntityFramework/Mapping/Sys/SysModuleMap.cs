using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Mapping.Sys
{
    public  class SysModuleMap :EntityTypeConfiguration<SysModuleEntity>
    {
        public SysModuleMap()
        {
            this.ToTable("SysModule");
            this.HasKey(t => t.Id);
        }
    }
}
