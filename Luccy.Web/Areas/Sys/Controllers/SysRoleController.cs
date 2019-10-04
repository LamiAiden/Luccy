using Abp.Web.Models;
using Luccy.Common.Enum;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysRole;
using Luccy.Sys.SysRole.Dto;
using Luccy.Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysRoleController : LuccyControllerBase
    {
        private ISysRoleApp _sysRoleApp;

        public SysRoleController(ISysRoleApp sysRoleApp, ISysModuleOperateApp sysModuleOperateApp) : base(sysModuleOperateApp)
        {
            _sysRoleApp = sysRoleApp;
        }
        // GET: Sys/SysRole
        public ActionResult Index()
        {
            ViewBag.permission = GetPermission().PermList;
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

        public ActionResult Form()
        {

            // List<Entity.Sys.SysUserEntity> List1= _sysUserApp.GetUserList();
            return View();
        }
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            RoleOutputDto data = _sysRoleApp.GetForm(keyValue);
            RoleDto dto = data.RoleDtoSingle;
            return Content(JsonConvert.SerializeObject(dto));
        }

        [HttpPost]
        [DontWrapResult]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RoleSubmitInputDto RoleDto)
        {
            _sysRoleApp.SubmitForm(RoleDto, GetUserInfo());
            return Json(new { state = ResultType.success.ToString(), message = "操作成功！" });

        }
        [HttpPost]
        [DontWrapResult]
        // [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(RoleDeleteInputDto RoleDto)
        {
            _sysRoleApp.DeleteForm(RoleDto);
            return Json(new { state = ResultType.success.ToString(), message = "删除成功！" });
        }

        [HttpGet]
        [DontWrapResult]
        public ActionResult GetGridJson()
        {
            var data = _sysRoleApp.GetList();
            return Content(JsonConvert.SerializeObject(data.RoleDtoList));
        }
    }
}