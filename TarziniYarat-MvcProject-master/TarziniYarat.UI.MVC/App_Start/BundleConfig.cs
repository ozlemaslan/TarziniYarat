using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TarziniYarat.UI.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/adminLayout").Include("~/Areas/Admin/Content/css/*.css"));

            bundles.Add(new ScriptBundle("~/js/adminLayout").Include("~/Areas/Admin/Content/js/jquery.min.js", "~/Areas/Admin/Content/js/bootstrap.bundle.min.js", "~/Areas/Admin/Content/js/jquery.easing.min.js", "~/Areas/Admin/Content/js/sb-admin-2.min.js", "~/Areas/Admin/Content/js/Chart.min.js", "~/Areas/Admin/Content/js/chart-area-demo.js", "~/Areas/Admin/Content/js/chart-pie-demo.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}