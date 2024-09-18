using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace TaskManager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-route.min.js",
                    "~/Scripts/angular-animate.min.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
               "~/wwwroot/app/app.js",
               "~/wwwroot/app/controller/home.js"
            ));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
               "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));

        }
    }
}

