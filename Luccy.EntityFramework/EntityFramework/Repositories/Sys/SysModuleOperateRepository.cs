using Abp.EntityFramework;
using Luccy.CommonModel;
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

        public List<PermModel> GetPermissionByUserIdAndUrl(string userId, string Url)
        {
            var db = GetDBContext();
            var query = from o in db.SysModuleOperate
                        join r in db.SysRight on o.Id equals r.ModuleOperateId
                        join g in db.SysRole2User on r.RoleId equals g.SysRoleId
                        join m in db.SysModule on o.ModuleId equals m.Id
                        where m.Url == Url && g.SysUserId == userId&&r.IsValid==true
                        select new PermModel
                        {
                           KeyCode= o.KeyCode,
                           IsValid= r.IsValid
                        };
            return query.ToList();
        }

    }
}
