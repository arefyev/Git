using System.Collections.Generic;

namespace ADV.Web.Models
{
    public class ProjectViewModel
    {
        public string Title { get; set; }
       
        public string Logo { get; set; }
        
        public string Period { get; set; }
       
        public string Company { get; set; }
        
        public string ShortDescription { get; set; }
        
        public string Description { get; set; }
       
        public IList<string> Tags { get; set; }
    }
}