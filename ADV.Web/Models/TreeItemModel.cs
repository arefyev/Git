using System.Collections.Generic;

namespace ADV.Web.Models
{
    public class TreeItemModel
    {
        public TreeItemModel()
        {
            Children = new List<TreeItemModel>();
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public IList<TreeItemModel> Children { get; set; }
    }
}