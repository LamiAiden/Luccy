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
    public  class SysRoleRepository: LuccyRepositoryBase<SysRoleEntity, string>, ISysRoleRepository
    {
        public SysRoleRepository(IDbContextProvider<LuccyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<SysRoleEntity> GetRoleListByPage(Pagination pagination, string keyword)
        {
            Expression<Func<SysRoleEntity, bool>> expression = b => 1 == 1;
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = t => t.Name.Contains(keyword);
            }
            return FindList(expression, pagination);
        }

    }
}
