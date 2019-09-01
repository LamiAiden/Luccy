using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Mapping.Sys
{
    class SysModuleOperateMap: EntityTypeConfiguration<SysModuleOperateEntity>
    {
        public SysModuleOperateMap()
        {
            this.ToTable("SysModuleOperate");
            this.HasKey(t => t.Id);
        }
    }
}
