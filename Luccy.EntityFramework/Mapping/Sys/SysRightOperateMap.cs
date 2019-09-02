using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Mapping.Sys
{
    public  class SysRightOperateMap : EntityTypeConfiguration<SysRightOperateEntity>
    {
        public SysRightOperateMap()
        {
            this.ToTable("SysRightOperate");
            this.HasKey(t => t.Id);
        }
    }
}
