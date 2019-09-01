using Abp.Web.Models;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModule;
using Luccy.Sys.SysUser;
using Luccy.Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysUserController :  LuccyControllerBase
    {
        private ISysModuleApp _sysModuleApp;
        private ISysUserApp _sysUserApp;
        public SysUserController(ISysUserApp sysUserApp, ISysModuleApp sysModuleApp)
        {
            _sysUserApp = sysUserApp;
            _sysModuleApp = sysModuleApp;
        }
        // GET: Sys/SysUser
        public ActionResult Index()
        {
           // List<Entity.Sys.SysUserEntity> List1= _sysUserApp.GetUserList();
            return View();
        }
        [DontWrapResult]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _sysUserApp.GetUserList(pagination, keyword).UserDtoList,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Content(JsonConvert.SerializeObject(data));
        }




    }
}