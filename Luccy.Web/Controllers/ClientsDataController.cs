using Abp.Web.Models;
using Luccy.Sys.SysModule;
using Luccy.Sys.SysModule.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Luccy.Web.Controllers
{
    public class ClientsDataController : LuccyControllerBase
    {
        private  ISysModuleApp _sysModuleApp;
        public ClientsDataController(ISysModuleApp sysModuleApp)
        {
            _sysModuleApp = sysModuleApp;
        }
        // GET: ClientsData
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        [DontWrapResult]
        [HttpGet]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = "",// this.GetDataItemList(),
                organize = "",//this.GetOrganizeList(),
                role = "",//this.GetRoleList(),
                duty = "",//this.GetDutyList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = "",//this.GetMenuButtonList(),
            };
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        private object GetMenuList()
        {
            // var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            // return ToMenuJson(new RoleAuthorizeApp().GetMenuList(roleId), "0");
            return ToMenuJson(_sysModuleApp.GetModuleList(), "0");
        }
        private string ToMenuJson(ModuleListOutputDto data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<ModuleDto> entitys = data.ModuleDtoList.FindAll(t => t.ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson =JsonConvert.SerializeObject(item);
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

    }
}