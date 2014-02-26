using System.Web;
using System.Web.Optimization;

namespace OnlineArkansas
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/training").Include(
                        "~/Scripts/training.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.10.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/oacss").Include(
                    "~/Content/style.css",
                    "~/Content/menu.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        

        bundles.Add(new StyleBundle("~/Content/themes/smoothness/css").Include(
                        "~/Content/themes/smoothness/jquery.ui.core.css",
                        "~/Content/themes/smoothness/jquery.ui.resizable.css",
                        "~/Content/themes/smoothness/jquery.ui.selectable.css",
                        "~/Content/themes/smoothness/jquery.ui.accordion.css",
                        "~/Content/themes/smoothness/jquery.ui.autocomplete.css",
                        "~/Content/themes/smoothness/jquery.ui.button.css",
                        "~/Content/themes/smoothness/jquery.ui.dialog.css",
                        "~/Content/themes/smoothness/jquery.ui.slider.css",
                        "~/Content/themes/smoothness/jquery.ui.tabs.css",
                        "~/Content/themes/smoothness/jquery.ui.datepicker.css",
                        "~/Content/themes/smoothness/jquery.ui.progressbar.css",
                        "~/Content/themes/smoothness/jquery.ui.theme.css"));
        }
    }
}