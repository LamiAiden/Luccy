using Abp.Web.Security.AntiForgery;
using Luccy.Common.CommonModel;
using Luccy.Common.Enum;
using Luccy.Common.Utils;
using System;
using System.Web.Mvc;

namespace Luccy.Web.Controllers
{
    public class HomeController : LuccyControllerBase
    {
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

        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult CheckLogin(string username, string password, string code)
        {
          //  LogEntity logEntity = new LogEntity();
           // logEntity.F_ModuleName = "系统登录";
          //  logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                if (Session["nfine_session_verifycode"]!=null || Md5.GetMD5(code.ToLower()) != Session["nfine_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                //UserEntity userEntity = new UserApp().CheckLogin(username, password);
                //if (userEntity != null)
                //{
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
                //}
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