using System;
using System.Collections.Generic;

namespace ADV.Biz
{
    public class Project
    {
        public Project()
        {
            Tags = new List<string>();
        }

        /// <summary>
        /// Project title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Project image name
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// Time when development was started
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Time when development was finished
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Company name
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Short project description
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// Project description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Is lovely project
        /// </summary>
        public bool Favorite { get; set; }
        /// <summary>
        /// Project tags
        /// </summary>
        public IList<string> Tags { get; set; }
    }
}
