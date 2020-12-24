using System.Web;
using System.Web.Optimization;

namespace AutoCompleteAngularJSDemo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendors/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendors/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendors/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendors/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/vendors/angular.js",
                      "~/Scripts/vendors/angular-route.js",
                      "~/Scripts/vendors/ui-bootstrap-tpls-3.0.6.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app/modules/common.core.js",
                      "~/Scripts/app/modules/common.ui.js",
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/controllers/rootCtrl.js",
                      "~/Scripts/app/controllers/home/homeCtrl.js",
                      "~/Scripts/app/services/apiService.js",
                      "~/Scripts/app/shared/inputDropdown.directive.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
