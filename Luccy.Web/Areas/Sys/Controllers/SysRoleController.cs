using Abp.Web.Models;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysRole;
using Luccy.Sys.SysRole.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysRoleController : Controller
    {
        private ISysRoleApp _sysRoleApp;

        public SysRoleController(ISysRoleApp sysRoleApp)
        {
            _sysRoleApp = sysRoleApp;
        }
        // GET: Sys/SysRole
        public ActionResult Index()
        {
            return View();
        }
        [DontWrapResult]
        public ActionResult GetTreeGridJson(Pagination pagination, string keyword)
        {
            SearchRoleInputDto inputDto = new SearchRoleInputDto(pagination, keyword);
            var data = new
            {
                rows = _sysRoleApp.GetRoleList(inputDto).RoleDtoList,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Content(JsonConvert.SerializeObject(data));
        }

    }
}