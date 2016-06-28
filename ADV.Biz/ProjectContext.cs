using ADV.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADV.Biz
{
    public sealed class ProjectContext
    {
        /// <summary>
        /// Returns all project for certain language
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static List<Project> ListProjects(string lang)
        {
            if (string.IsNullOrEmpty(lang))
                throw new ArgumentNullException("Language can't be empty");

            var listDto = DataContext.ListProjects(lang);
            return listDto.Where(p => !string.IsNullOrEmpty(p.Title)).Select(BindProject).ToList();
        }
        /// <summary>
        /// Returns unique tags from all projects
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        public static IList<string> BuildTagsFilter(IList<Project> projects)
        {
            var list = new List<string>();
            foreach (var t in projects.SelectMany(p => p.Tags.Where(t => !list.Contains(t))))
                list.Add(t);
            return list;
        }
        /// <summary>
        /// Transform project dto object to project business model
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        private static Project BindProject(ProjectDto projectDto)
        {
            return new Project
            {
                Title = projectDto.Title,
                Company = projectDto.Company,
                Description = projectDto.Description,
                ShortDescription = projectDto.ShortDescription,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate == default(DateTime) ? null : projectDto.EndDate,
                Logo = projectDto.Logo,
                Tags = projectDto.Tag,
                Favorite = projectDto.Favorite
            };
        }

    }
}
