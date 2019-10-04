using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Luccy.Common.Enum;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysModuleOperate.Dto;
using Luccy.Sys.SysRight;
using Luccy.Sys.SysRight.Dto;
using Luccy.Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysModuleOperateController : LuccyControllerBase
    {
        private ISysModuleOperateApp _sysModuleOperateApp;
        private ISysRightApp _sysRightApp;
        public SysModuleOperateController(ISysModuleOperateApp sysModuleOperateApp, ISysRightApp sysRightApp):base(sysModuleOperateApp)
        {
            _sysModuleOperateApp = sysModuleOperateApp;
            _sysRightApp = sysRightApp;
        }
        // GET: Sys/SysModuleOperate
        public ActionResult Index()
        {
            ViewBag.permission = GetPermission().PermList;
            return View();
        }

        public ActionResult Form()
        {

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
            ModuleOperateOutputDto data = _sysModuleOperateApp.GetForm(keyValue);
            ModuleOperateDto dto = data.ModuleOperateDtoSingle;
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
        public ActionResult SubmitForm(ModuleOperateSumbitInputDto ModuleOperateDto)
        {
            _sysModuleOperateApp.SubmitForm(ModuleOperateDto, GetUserInfo());
            return Json(new { state = ResultType.success.ToString(), message = "操作成功！" });

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        [DontWrapResult]
       // [DisableAbpAntiForgeryTokenValidation]
        public ActionResult DeleteForm(ModuleOperateDeleteInputDto deleteDto)
        {
            _sysModuleOperateApp.DeleteForm(deleteDto);
            return Json(new { state = ResultType.success.ToString(), message = "删除成功！" });
        }

        [HttpGet]
        [DontWrapResult]
        public ActionResult GetMenuGridJson(string menuId)
        {
            ModuleOperateInputDto inputDto = new ModuleOperateInputDto();
            inputDto.Mid = menuId;
            inputDto.Pagination = new Pagination();
            var data = _sysModuleOperateApp.GetList(inputDto);        
            return Content(JsonConvert.SerializeObject(data.ModuleOperateList));
        }

        [HttpGet]
        [DontWrapResult]
        public ActionResult GetGridJson(string itemId,string roleId)
        {
            ModuleOperateInputDto inputDto = new ModuleOperateInputDto();
            inputDto.Mid = itemId;
            inputDto.Pagination = new Pagination();
            var data = _sysModuleOperateApp.GetList(inputDto);
            RightInputDto rInputDto = new RightInputDto();
            rInputDto.RoleId = roleId;
            rInputDto.Mid = itemId;
            var data1 = _sysRightApp.GetAllRightByRoleIdAndMId(rInputDto);
            if(data1.RightList.Count>0&&data.ModuleOperateList.Count>0)
            {
                foreach(RightDto d in data1.RightList)
                {
                    for(int i=0;i< data.ModuleOperateList.Count;i++)
                    {
                        if (d.ModuleOperateId == data.ModuleOperateList[i].Id)
                        {
                            data.ModuleOperateList[i].IsValid = d.IsValid;
                        }
                    }
                }
            }
            return Content(JsonConvert.SerializeObject(data.ModuleOperateList));
        }
    }
}