using Abp.Web.Mvc.Controllers;

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
    }
}