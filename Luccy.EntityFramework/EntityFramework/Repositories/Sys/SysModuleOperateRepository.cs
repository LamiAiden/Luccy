using Abp.EntityFramework;
using Luccy.Core.CommonModel;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.EntityFramework.Repositories.Sys
{
    class SysModuleOperateRepository : LuccyRepositoryBase<SysModuleOperateEntity, string>, ISysModuleOperateRepository
    {
        public SysModuleOperateRepository(IDbContextProvider<LuccyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public List<SysModuleOperateEntity> GetModuleOperateListByPage(Pagination pagination, string mid)
        {
            Expression<Func<SysModuleOperateEntity, bool>> expression = b => 1 == 1;
            if (!string.IsNullOrEmpty(mid))
            {
                expression = t => t.ModuleId.Equals(mid);
            }
            return FindList(expression, pagination);
        }
    }
}
