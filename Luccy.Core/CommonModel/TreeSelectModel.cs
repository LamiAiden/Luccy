using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.CommonModel
{
    public class TreeSelectModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parentId { get; set; }
        public object data { get; set; }
    }
    public class TreeSelect
    {

        public static string TreeSelectJson(List<TreeSelectModel> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(TreeSelectJson(data, "0", ""));
            sb.Append("]");
            return sb.ToString();
        }
        private static string TreeSelectJson(List<TreeSelectModel> data, string parentId, string blank)
        {
            StringBuilder sb = new StringBuilder();
            var ChildNodeList = data.FindAll(t => t.parentId == parentId);
            var tabline = "";
            if (parentId != "0")
            {
                tabline = "　　";
            }
            if (ChildNodeList.Count > 0)
            {
                tabline = tabline + blank;
            }
            foreach (TreeSelectModel entity in ChildNodeList)
            {
                entity.text = tabline + entity.text;
                string strJson =Newtonsoft.Json.JsonConvert.SerializeObject(entity);
                sb.Append(strJson);
                sb.Append(TreeSelectJson(data, entity.id, tabline));
            }
            return sb.ToString().Replace("}{", "},{");
        }
    }
}
