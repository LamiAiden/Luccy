using Abp.EntityFramework;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.EntityFramework.Repositories.Sys
{
    public  class SysRole2UserRepository: LuccyRepositoryBase<SysRole2UserEntity, string>, ISysRole2UserRepository
    {
        public SysRole2UserRepository(IDbContextProvider<LuccyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
