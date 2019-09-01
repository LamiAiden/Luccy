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
    public  interface ISysModuleOperateRepository: IRepository<SysModuleOperateEntity, string>
    {
        List<SysModuleOperateEntity> GetModuleOperateListByPage(Pagination pagination, string mid);
    }
}
