using System;
using ADV.Biz;
using ADV.Web.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Resources;

namespace ADV.Web.Code
{
    public class DataHelper
    {
        public static ProjectsViewModel GetProjectsSolution()
        {
            //string path = HttpContext.Current.Server.MapPath(String.Format("~/App_Data/Projects_{0}.xml", UIHelper.DetectLang()));
            var projects = ProjectContext.ListProjects(UIHelper.DetectLang());
            var model = new ProjectsViewModel { Projects = ConvertProjects(projects.OrderByDescending(p => p.StartDate).ToList()), Tags = ProjectContext.BuildTagsFilter(projects).OrderBy(t => t).ToList() };
            return model;
        }

        public static List<ProjectViewModel> ConvertProjects(List<Project> projects)
        {
            if (projects == null)
                return null;

            return projects.Select(x => new ProjectViewModel { Title = x.Title, Company = x.Company, Description = x.Description, Logo = x.Logo, ShortDescription = x.ShortDescription, Period = ConvertDate(x.StartDate, x.EndDate), Tags = x.Tags }).ToList();
        }

        private static string ConvertDate(DateTime start, DateTime? end)
        {
            var culture = Thread.CurrentThread.CurrentUICulture;

            return String.Format("{0} - {1}", start.ToString(Variables.DateProjectFormat, culture), end.HasValue ? end.Value.ToString(Variables.DateProjectFormat, culture) : Texts.Now);
        }
    }
}