using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Luccy.Sys.SysUser
{
    public  class SysUserApp : LuccyAppServiceBase, ISysUserApp
    {
        private readonly IRepository<Entity.Sys.SysUser, string> _sysUserRepository;


    }
}
