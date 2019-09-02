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
    public  class SysRightRepository: LuccyRepositoryBase<SysRightEntity, string>, ISysRightRepository
    {
        public SysRightRepository(IDbContextProvider<LuccyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
