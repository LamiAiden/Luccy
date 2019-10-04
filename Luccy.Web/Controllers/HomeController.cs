using Abp.Runtime.Session;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Luccy.Common.Enum;
using Luccy.Common.Utils;
using Luccy.CommonModel;
using Luccy.Core.CommonModel;
using Luccy.Sys.SysModuleOperate;
using Luccy.Sys.SysRight;
using Luccy.Sys.SysUser;
using Luccy.Sys.SysUser.Dto;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Luccy.Web.Controllers
{
    public class HomeController : LuccyControllerBase
    {
        private ISysUserApp _sysUser;
        private ISysModuleOperateApp _sysModuleOperateApp;
        private ISysRightApp _sysRightApp;
        public HomeController(ISysUserApp sysUser, ISysModuleOperateApp sysModuleOperateApp, ISysRightApp sysRightApp):base(sysModuleOperateApp)
        {
            _sysUser = sysUser;
            _sysModuleOperateApp = sysModuleOperateApp;
            _sysRightApp = sysRightApp;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        //[DisableAbpAntiForgeryTokenValidation]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [DontWrapResult]
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            string ss= Md5.GetMD5(code.ToLower());
            try
            {
                if (SessionHelper.GetSession(SessionKey.session_verifycode.ToString())==string.Empty || Md5.GetMD5(code.ToLower()) != SessionHelper.GetSession(SessionKey.session_verifycode.ToString()))
                {
                    string dds = SessionHelper.GetSession(SessionKey.session_verifycode.ToString());
                    string dd = Session[SessionKey.session_verifycode.ToString()].ToString();
                    throw new Exception("验证码错误，请重新输入");
                }
                LoginInputDto inputDto = new LoginInputDto(username, Md5.GetMD5(password));
                UserDto  userDto = _sysUser.CheckLogin(inputDto);
                if (userDto != null)
                {
                    UserInfo info = new UserInfo();
                    info.UserID = userDto.Id;
                    info.UserName = userDto.UserName;
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                    (1, JsonConvert.SerializeObject(info), DateTime.Now, DateTime.Now.AddMinutes(20), true, "role");
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                }          
                return Json(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message });
            }
        }
    }
}