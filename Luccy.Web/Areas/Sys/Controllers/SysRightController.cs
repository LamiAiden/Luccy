using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Luccy.Common.Enum;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysModuleOperate.Dto;
using Luccy.Sys.SysRight;
using Luccy.Sys.SysRight.Dto;
using Luccy.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysRightController : LuccyControllerBase
    {
        private ISysRightApp _sysRightApp;

        public SysRightController(ISysRightApp sysRightApp, ISysModuleOperateApp sysModuleOperateApp) : base(sysModuleOperateApp)
        {
            _sysRightApp = sysRightApp;
        }
        // GET: Sys/SysRight
        public ActionResult Index()
        {
            ViewBag.permission = GetPermission().PermList;
            return View();
        }

        [HttpPost]
        [DontWrapResult]
        [DisableAbpAntiForgeryTokenValidation]
       // public ActionResult SetRight(ModuleOperateDto operateDto,string roleId)
        public ActionResult SetRight(RightInputDto dto)
        {
            _sysRightApp.SetRight(dto);
            return Json(new { state = ResultType.success.ToString(), message = "保存成功！" });
        }
    }
}