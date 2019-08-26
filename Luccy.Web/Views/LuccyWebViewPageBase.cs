using Abp.Web.Mvc.Views;

namespace Luccy.Web.Views
{
    public abstract class LuccyWebViewPageBase : LuccyWebViewPageBase<dynamic>
    {

    }

    public abstract class LuccyWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected LuccyWebViewPageBase()
        {
            LocalizationSourceName = LuccyConsts.LocalizationSourceName;
        }
    }
}