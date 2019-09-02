using Abp.Domain.Repositories;
using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.IRepository.Sys
{
    public  interface ISysRightOperateRepository: IRepository<SysRightOperateEntity, string>
    {
    }
}
