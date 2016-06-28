using System.Web.Optimization;

namespace ADV.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
             "~/Scripts/app-helper.js",
             "~/Scripts/jquery.js",
             "~/Scripts/angular.js",
             "~/Scripts/angular-ui-router.js",
             "~/Scripts/ui-bootstrap-tpls-1.1.2.js",
             "~/Scripts/angular-sanitize.js",
             "~/Scripts/angular-route.js",
             "~/Scripts/angular-animate.js",
             "~/Scripts/app-common.js",
             "~/Scripts/app-controllers.js"));

            bundles.Add(new ScriptBundle("~/bundles/ewscripts").Include(
           // "~/Scripts/app-helper.js",
            //"~/Scripts/jquery.js",
            "~/Scripts/angular.js",
            "~/Scripts/angular-ui-router.js",
            "~/Scripts/ui-bootstrap-tpls-1.1.2.js",
            "~/Scripts/angular-sanitize.js",
            "~/Scripts/angular-route.js",
            "~/Scripts/angular-animate.js",
            // "~/Scripts/app-common.js",
            "~/Scripts/ew-controllers.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/font-awesome/css/font-awesome.css",
                "~/Content/css/bootstrap.css",
                "~/Content/css/preloader.css",
                "~/Content/css/main.css",
                "~/Content/css/thema-modern.css"
                ));
            bundles.Add(new StyleBundle("~/bundles/ewcss").Include(
               "~/Content/font-awesome/css/font-awesome.css",
               "~/Content/css/bootstrap.css"
               ));
        }
    }
}