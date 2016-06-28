using System.Collections.Generic;

namespace ADV.Data
{
    public interface IRepository
    {
        /// <summary>
        /// Returns all project from storage for certain language
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        IEnumerable<ProjectDto> ListProjects(string lang);
    }
}
