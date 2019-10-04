using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Luccy.Common.Enum;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModule;
using Luccy.Sys.SysModule.Dto;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysModuleOperate.Dto;
using Luccy.Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysModuleController : LuccyControllerBase
    {
        private ISysModuleApp _sysModuleApp;
        private ISysModuleOperateApp _sysModuleOperateApp;
        public SysModuleController(ISysModuleApp sysModuleApp, ISysModuleOperateApp sysModuleOperateApp):base(sysModuleOperateApp)
        {
            _sysModuleApp = sysModuleApp;
            _sysModuleOperateApp = sysModuleOperateApp;
        }
        // GET: Sys/SysMudule
        public ActionResult Index()
        {
            ViewBag.permission = GetPermission().PermList;
            return View();
        }


        
        [HttpGet]
        [DontWrapResult]
        public ActionResult GetTreeSelectJson()
        {
            ModuleOutputDto OutputDto = _sysModuleApp.GetTreeSelectJson();
            return Content(OutputDto.TreeSelectJson);
        }
        [HttpGet]
        [DontWrapResult]
        public ActionResult GetTreeGridJson()
        {
            ModuleOutputDto OutputDto = _sysModuleApp.GetTreeGridList();              
            return Content(OutputDto.TreeGridJson);
        }

        [HttpGet]
        [DontWrapResult]
        public ActionResult GetTreeViewJson()
        {
            ModuleOutputDto OutputDto = _sysModuleApp.GetTreeViewList();
            return Content(OutputDto.TreeViewJson);
        }

        /// <summary>
        /// 新增修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Form()
        {

            // List<Entity.Sys.SysUserEntity> List1= _sysUserApp.GetUserList();
            return View();
        }
        /// <summary>
        /// 根据ID获取修改数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            ModuleOutputDto data = _sysModuleApp.GetForm(keyValue);
            ModuleDto dto = data.UserDtoSingle;
            return Content(JsonConvert.SerializeObject(dto));
        }
        /// <summary>
        /// 提交修改信息
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        [DontWrapResult]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ModuleSumbitInputDto userDto)
        {
            _sysModuleApp.SubmitForm(userDto, GetUserInfo());
            return Json(new { state = ResultType.success.ToString(), message = "操作成功！" });

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        [DontWrapResult]
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult DeleteForm(ModuleDeleteInputDto userDto)
        {
            _sysModuleApp.DeleteForm(userDto);
            return Json(new { state = ResultType.success.ToString(), message = "删除成功！" });
        }


        //[DontWrapResult]
        //[HttpPost]
        //public JsonResult GetList(string id)
        //{
        //    if (id == null)
        //        id = "0";
        //    SearchModuleInputDto inputDto = new SearchModuleInputDto();
        //    inputDto.ParentId=id;
        //    ModuleOutputDto OutputDto = _sysModuleApp.GetList(inputDto);        
        //    return Json(OutputDto.ModuleDtoList);
        //}

        [DontWrapResult]
        // [SupportFilter(ActionName = "Index")]
        public JsonResult GetOptListByModule(Pagination pagination, string mid)
        {
            if (string.IsNullOrEmpty(mid))
                mid = "0";
            ModuleOperateInputDto inputDto = new ModuleOperateInputDto(pagination, mid);
            ModuleOperateOutputDto outputDto = _sysModuleOperateApp.GetList(inputDto);
            return Json(outputDto.ModuleOperateList);
        }

    }
}