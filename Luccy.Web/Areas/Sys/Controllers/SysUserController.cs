using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Castle.Core.Logging;
using Luccy.Common.Enum;
using Luccy.CommonModel;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModule;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysRole;
using Luccy.Sys.SysRole2User;
using Luccy.Sys.SysRole2User.Dto;
using Luccy.Sys.SysUser;
using Luccy.Sys.SysUser.Dto;
using Luccy.Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    [DontWrapResult]
    public class SysUserController : LuccyControllerBase
    {
        private ISysModuleApp _sysModuleApp;
        private ISysUserApp _sysUserApp;
        private ISysRoleApp _sysRoleApp;
        private ISysRole2UserApp _sysRole2UserApp;
        private ILogger _log;
        public SysUserController(ISysUserApp sysUserApp, ISysModuleApp sysModuleApp, ILogger log, ISysRoleApp sysRoleApp, ISysRole2UserApp sysRole2UserApp,ISysModuleOperateApp sysModuleOperateApp):base(sysModuleOperateApp)
        {
            _sysUserApp = sysUserApp;
            _sysModuleApp = sysModuleApp;
            _log = log;
            _sysRoleApp = sysRoleApp;
            _sysRole2UserApp = sysRole2UserApp;
        }
        // GET: Sys/SysUser
        public ActionResult Index()
        {
            ViewBag.permission = GetPermission().PermList;
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

        public ActionResult Form()
        {

            // List<Entity.Sys.SysUserEntity> List1= _sysUserApp.GetUserList();
            return View();
        }
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            UserOutputDto data = _sysUserApp.GetForm(keyValue);
            UserDto dto = data.UserDtoSingle;
            if (!string.IsNullOrEmpty(keyValue))
            {
                Role2UserInputDto inputDto = new Role2UserInputDto();
                inputDto.SysUserId = keyValue;
                if(_sysRole2UserApp.GetRole2UserByUserId(inputDto).Role2UserDto!=null)
                    dto.RoleId = _sysRole2UserApp.GetRole2UserByUserId(inputDto).Role2UserDto.SysRoleId;
            }
            return Content(JsonConvert.SerializeObject(dto));
        }

        [HttpPost]
        [DontWrapResult]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(UserInputDto userDto)
        {
            _sysUserApp.SubmitForm(userDto, GetUserInfo());
            return Json(new { state = ResultType.success.ToString(), message = "操作成功！" });
         
        }
        [HttpPost]
        [DontWrapResult]
        public ActionResult DeleteForm(UserDeleteInputDto userDto)
        {
            _sysUserApp.DeleteForm(userDto);
            return Json(new { state = ResultType.success.ToString(), message = "删除成功！" });
        }

        [HttpGet]
        [DontWrapResult]
        public ActionResult GetRoleJson()
        {
            var data = _sysRoleApp.GetList();
            return Content(JsonConvert.SerializeObject(data.RoleDtoList));
        }
    }
}