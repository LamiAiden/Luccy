using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Mapping.Sys
{
    public  class SysRole2UserMap : EntityTypeConfiguration<SysRole2UserEntity>
    {
        public SysRole2UserMap()
        {
            this.ToTable("SysRole2User");
            this.HasKey(t => t.Id);
        }
    }
}
