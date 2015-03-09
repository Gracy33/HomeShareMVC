using System.Web;
using System.Web.Optimization;

namespace HomeShareMVC
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le regroupement, rendez-vous sur http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.9.1.min.js",
                        "~/Scripts/script.js",
                        "~/Scripts/modernizr.custom.79639.js",
                        "~/Scripts/jquery.ba-cond.min.js",
                        "~/Scripts/jquery.slitslider.js",
                        "~/Scripts/owl.carousel.js"                        
                        ));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css")
               .Include("~/Content/css/bootstrap.min.css",
               "~/Content/css/font-awesome.min.css",
               "~/Content/css/bootstrap.css",
               "~/Content/css/style.css",
               "~/Content/css/Site.css",
               "~/Content/css/slitslider/style.css",
               "~/Content/css/slitslider/custom.css",
               "~/Content/css/owl-carousel/owl.carousel.css",
               "~/Content/css/owl-carousel/owl.theme.css"               
               ));
        }
    }
}
