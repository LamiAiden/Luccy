using Abp.EntityFramework;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.EntityFramework.Repositories.Sys
{
    public class SysRightRepository : LuccyRepositoryBase<SysRightEntity, string>, ISysRightRepository
    {
        public SysRightRepository(IDbContextProvider<LuccyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public void SetRight(string rentityId, List<SysModuleOperateEntity> moentity)
        {
            var dbcontext = GetDbContext();
            foreach (SysModuleOperateEntity ent in moentity)
            {
                SysRightEntity rentityobj = dbcontext.Set<SysRightEntity>().Where(b => b.ModuleOperateId.Equals(ent.Id) && b.RoleId.Equals(rentityId)).FirstOrDefault();
                if (rentityobj == null)
                {
                    rentityobj = new SysRightEntity();
                    rentityobj.Id = Guid.NewGuid().ToString();
                    rentityobj.RoleId = rentityId;
                    rentityobj.ModuleOperateId = ent.Id;
                    dbcontext.Set<SysRightEntity>().Add(rentityobj);
                }
                else
                {
                    if (rentityobj.IsValid != ent.IsValid)
                    {
                        rentityobj.IsValid = ent.IsValid;
                    }
                }
            }
            dbcontext.SaveChanges();
        }

        public List<SysRightEntity> GetAllRightByRIdAndMid(string roleId, string mId)
        {
            var db = GetDBContext();
            var query = from o in db.SysModuleOperate
                        join r in db.SysRight on o.Id equals r.ModuleOperateId
                        where o.ModuleId == mId && r.RoleId == roleId
                        select r;
            return query.ToList();
        }

       
    }
}
