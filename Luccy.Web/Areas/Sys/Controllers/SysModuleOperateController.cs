using Abp.Web.Models;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysModuleOperate.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Areas.Sys.Controllers
{
    public class SysModuleOperateController : Controller
    {
        private ISysModuleOperateApp _sysModuleOperateApp;
        public SysModuleOperateController(ISysModuleOperateApp sysModuleOperateApp)
        {
            _sysModuleOperateApp = sysModuleOperateApp;
        }
        // GET: Sys/SysModuleOperate
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public ActionResult GetGridJson(string itemId)
        {
            ModuleOperateInputDto inputDto = new ModuleOperateInputDto();
            inputDto.Mid = itemId;
            inputDto.Pagination = new Pagination();
            var data = _sysModuleOperateApp.GetList(inputDto);
            return Content(JsonConvert.SerializeObject(data.ModuleOperateList));
        }
    }
}