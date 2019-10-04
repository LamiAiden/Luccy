using Abp.Web.Mvc.Controllers;
using Luccy.CommonModel;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysModuleOperate.Dto;
using Newtonsoft.Json;
using System.Web;
using System.Web.Security;

namespace Luccy.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class LuccyControllerBase : AbpController
    {
        private ISysModuleOperateApp _sysModuleOperateApp;
        protected LuccyControllerBase(ISysModuleOperateApp sysModuleOperateApp)
        {
            _sysModuleOperateApp = sysModuleOperateApp;
            // Menu = menu;
            LocalizationSourceName = LuccyConsts.LocalizationSourceName;
        }
        protected UserInfo GetUserInfo()
        {
            string infoJson = System.Web.HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName).Value;
            FormsAuthenticationTicket s33s = FormsAuthentication.Decrypt(infoJson);
            UserInfo user = JsonConvert.DeserializeObject<UserInfo>(s33s.Name);
            return user;
        }

        public ModuleOperateOutputDto GetPermission()
        {
            string controller=  RouteData.Route.GetRouteData(this.HttpContext).Values["controller"].ToString();
            string url = "/Sys/" + controller;
            ModuleOperateSearchInputDto searchInput = new ModuleOperateSearchInputDto();
            searchInput.UserId = GetUserInfo().UserID;
            searchInput.Url = url;
            ModuleOperateOutputDto outdto= _sysModuleOperateApp.GetPermissionByUserIdAndUrl(searchInput);
            return outdto;
        }


    }
}