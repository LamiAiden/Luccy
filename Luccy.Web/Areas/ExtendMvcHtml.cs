using Luccy.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace System.Web.Mvc
{
    public static class ExtendMvcHtml
    {
        /// <summary>
        /// 权限按钮
        /// </summary>
        /// <param name="helper">htmlhelper</param>
        /// <param name="id">控件Id</param>
        /// <param name="icon">控件icon图标class</param>
        /// <param name="text">控件的名称</param>
        /// <param name="perm">权限列表</param>
        /// <param name="keycode">操作码</param>
        /// <param name="hr">分割线</param>
        /// <returns>html</returns>
        public static MvcHtmlString ToolButton(this HtmlHelper helper,string classa, string id, string icon, string text, List<PermModel> perm, string keycode,string action, bool hr)
        {
            if (perm.Where(a => a.KeyCode == keycode).Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<a id = \"{0}\"  class=\"{1}\" onclick =\"{2}\" ><i class=\"{3}\"></i>{4}</a>", id, classa, action,icon,text);
                if (hr)
                {
                    sb.Append("<div></div>");
                }
                return new MvcHtmlString(sb.ToString());
            }
            else
            {
                return new MvcHtmlString("");
            }
        }
    }
}
