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
    class SysRightOperateRepository : LuccyRepositoryBase<SysRightOperateEntity, string>, ISysRightOperateRepository
    {
        public SysRightOperateRepository(IDbContextProvider<LuccyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
