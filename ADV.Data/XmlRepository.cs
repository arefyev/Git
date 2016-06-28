using ADV.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace ADV.Data
{
    /// <summary>
    /// Xml data repository
    /// </summary>
    public sealed class XmlRepository : IRepository
    {
        /// <summary>
        /// List all project for certain language
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectDto> ListProjects(string lang)
        {
            if (String.IsNullOrEmpty(lang))
                return null;
            // bad practice, better send path from web layer for specified repository only
            var path = HttpContext.Current.Server.MapPath(String.Format("~/App_Data/Projects_{0}.xml", lang));

            if (!File.Exists(path))
                return null;

            try
            {
                var text = File.ReadAllText(path);
                var data = XmlSerializeHelper.Deserialize<ProjectDtoCollection>(text);

                return data.Items;
            }
            catch (Exception)
            {
                // log error
                return null;
            }
        }
    }
}
