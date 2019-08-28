using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Mapping.Sys
{
    public  class SysUserMap: EntityTypeConfiguration<SysUser>
    {
        public SysUserMap()
        {
            this.ToTable("SysUser");
            this.HasKey(t => t.Id);
        }
    }
}
