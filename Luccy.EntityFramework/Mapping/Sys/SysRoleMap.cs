using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Mapping.Sys
{
    public  class SysRoleMap: EntityTypeConfiguration<SysRoleEntity>
    {
        public SysRoleMap()
        {
            this.ToTable("SysRole");
            this.HasKey(t => t.Id);
        }
    }
}
