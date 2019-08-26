using Abp.Application.Services;

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