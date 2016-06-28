using System.Web.Mvc;

namespace ADV.Web.Code
{
    public static class WebUrlHelper
    {
        /// <summary>
        /// Return path to image for certain image
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Image(this UrlHelper helper, string fileName)
        {
            return helper.Content("~/Content/img/" + fileName);
        }
        /// <summary>
        /// Path to project image folder
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string ProjectImagePath(this UrlHelper helper)
        {
            return helper.Content("~/Content/img/Projects/");
        }
    }
}