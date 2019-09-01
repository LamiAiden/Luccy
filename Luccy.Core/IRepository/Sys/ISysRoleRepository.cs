using Abp.Domain.Repositories;
using Luccy.Core.CommonModel;
using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.IRepository.Sys
{
    public  interface ISysRoleRepository:IRepository<SysRoleEntity,string>
    {
        List<SysRoleEntity> GetRoleListByPage(Pagination pagination, string keyword);
    }
}
