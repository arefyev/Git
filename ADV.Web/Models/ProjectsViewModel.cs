using System.Collections.Generic;

namespace ADV.Web.Models
{
    public sealed class ProjectsViewModel
    {
        /// <summary>
        /// Projects list
        /// </summary>
        public IList<ProjectViewModel> Projects { get; set; }
        /// <summary>
        /// Tags for filter
        /// </summary>
        public IList<string> Tags { get; set; }
    }
}