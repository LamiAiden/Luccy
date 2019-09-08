using Abp.Application.Services;
using Luccy.CommonModel;

namespace Luccy
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class LuccyAppServiceBase : ApplicationService
    {
        protected LuccyAppServiceBase()
        {
            LocalizationSourceName = LuccyConsts.LocalizationSourceName;
        }
    }
}