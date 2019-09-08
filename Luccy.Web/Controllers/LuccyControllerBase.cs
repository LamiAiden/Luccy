using Abp.Web.Mvc.Controllers;
using Luccy.CommonModel;
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
        protected LuccyControllerBase()
        {
            LocalizationSourceName = LuccyConsts.LocalizationSourceName;
        }
        protected UserInfo GetUserIngo()
        {
            string infoJson = System.Web.HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName).Value;
            FormsAuthenticationTicket s33s = FormsAuthentication.Decrypt(infoJson);
            UserInfo user = JsonConvert.DeserializeObject<UserInfo>(s33s.Name);
            return user;
        }
    }
}