using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Luccy.Common.Enum;
using Luccy.Common.Utils;
using Luccy.CommonModel;
using Luccy.Core.CommonModel;
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
        public HomeController(ISysUserApp sysUser)
        {
            _sysUser = sysUser;
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
            //  LogEntity logEntity = new LogEntity();
            // logEntity.F_ModuleName = "系统登录";
            //  logEntity.F_Type = DbLogType.Login.ToString();
            string ss= Md5.GetMD5(code.ToLower());
            try
            {
                if (SessionHelper.GetSession(SessionKey.session_verifycode.ToString())==string.Empty || Md5.GetMD5(code.ToLower()) != SessionHelper.GetSession(SessionKey.session_verifycode.ToString()))
                {
                    string dds = SessionHelper.GetSession(SessionKey.session_verifycode.ToString());
                    string dd = Session[SessionKey.session_verifycode.ToString()].ToString();
                    throw new Exception("验证码错误，请重新输入");
                }

                UserDto  userDto = _sysUser.CheckLogin(username, Md5.GetMD5(password));
                if (userDto != null)
                {
                    UserInfo info = new UserInfo();
                    info.UserID = userDto.Id;
                    info.UserName = userDto.UserName;
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                    (1, JsonConvert.SerializeObject(info), DateTime.Now, DateTime.Now.AddMinutes(20), false, "");
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                    //    OperatorModel operatorModel = new OperatorModel();
                    //    operatorModel.UserId = userEntity.F_Id;
                    //    operatorModel.UserCode = userEntity.F_Account;
                    //    operatorModel.UserName = userEntity.F_RealName;
                    //    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    //    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    //    operatorModel.RoleId = userEntity.F_RoleId;
                    //    operatorModel.LoginIPAddress = Net.Ip;
                    //    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    //    operatorModel.LoginTime = DateTime.Now;
                    //    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    //    if (userEntity.F_Account == "admin")
                    //    {
                    //        operatorModel.IsSystem = true;
                    //    }
                    //    else
                    //    {
                    //        operatorModel.IsSystem = false;
                    //    }
                    //    OperatorProvider.Provider.AddCurrent(operatorModel);
                    //    logEntity.F_Account = userEntity.F_Account;
                    //    logEntity.F_NickName = userEntity.F_RealName;
                    //    logEntity.F_Result = true;
                    //    logEntity.F_Description = "登录成功";
                    //    new LogApp().WriteDbLog(logEntity);
                }
               
                return Json(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" });
            }
            catch (Exception ex)
            {
                //logEntity.F_Account = username;
                //logEntity.F_NickName = username;
                //logEntity.F_Result = false;
                //logEntity.F_Description = "登录失败，" + ex.Message;
                //new LogApp().WriteDbLog(logEntity);
                return Json(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message });
            }
        }
    }
}