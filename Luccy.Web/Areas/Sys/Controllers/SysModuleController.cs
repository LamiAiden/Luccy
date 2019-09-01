using Abp.Web.Models;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModule;
using Luccy.Sys.SysModule.Dto;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysModuleOperate.Dto;
using Luccy.Web.Controllers;
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
        public SysModuleController(ISysModuleApp sysModuleApp, ISysModuleOperateApp sysModuleOperateApp)
        {
            _sysModuleApp = sysModuleApp;
            _sysModuleOperateApp = sysModuleOperateApp;
        }
        // GET: Sys/SysMudule
        public ActionResult Index()
        {
            return View();
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