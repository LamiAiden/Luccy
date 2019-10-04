using Abp.Domain.Repositories;
using Luccy.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.IRepository.Sys
{
    public interface ISysRightRepository  : IRepository<SysRightEntity, string>
    {
        void SetRight(string rentityId, List<SysModuleOperateEntity> moentity);
        List<SysRightEntity> GetAllRightByRIdAndMid(string roleId, string mId);

    }
}
