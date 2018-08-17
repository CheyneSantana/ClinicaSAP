using System.Web;
using System.Web.Optimization;

namespace SAPClinica
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Styles
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/cssTemplate").Include("~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include("~/Content/font-awesome.min.css"));
            #endregion

            #region Scripts
            // Jquery
            bundles.Add(new ScriptBundle("~/lib/jquery").Include("~/Scripts/lib/primary/jquery/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/lib/jqueryval").Include("~/Scripts/lib/primary/jquery/jquery.validate*"));

            // Angular
            bundles.Add(new ScriptBundle("~/lib/angular").Include("~/Scripts/lib/primary/angular/angular.js"));

            // JS
            bundles.Add(new ScriptBundle("~/lib").IncludeDirectory("~/Scripts/lib/secondary", "*.js", true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/lib/secondary/modernizr-*"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/lib/bootstrap").Include(
                "~/Scripts/lib/secondary/bootstrap/bootstrap.js", 
                "~/Scripts/lib/secondary/respond.js"));

            //Scripts template
            bundles.Add(new ScriptBundle("~/bundles/jsTemplates").Include(
                "~/Scripts/template/custom.js",
                "~/Scripts/template/gmaps.js",
                "~/Scripts/template/html5shiv.js",
                "~/Scripts/template/smoothscroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/ngmask").Include("~/Scripts/lib/secondary/plugins/ngmask/ngMask.min.js"));

            bundles.Add(new ScriptBundle("~/viewsjs").IncludeDirectory("~/Views/SAP", "*.js", true));

            #endregion

            #region Scripts SAP
            bundles.Add(new ScriptBundle("~/bundles/Consultas").Include(
                "~/Scripts/js/SAP/Consultas/ConsultasController.js",
                "~/Scripts/js/SAP/Consultas/ConsultasService.js"));

            bundles.Add(new ScriptBundle("~/bundles/Praja").Include(
                "~/Scripts/js/SAP/Praja/PrajaController.js",
                "~/Scripts/js/SAP/Praja/PrajaService.js"));

            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                "~/Scripts/js/SAP/Home/HomeController.js",
                "~/Scripts/js/SAP/Home/HomeService.js"));

            bundles.Add(new ScriptBundle("~/bundles/NossaEquipe").Include(
                "~/Scripts/js/SAP/NossaEquipe/NossaEquipeController.js",
                "~/Scripts/js/SAP/NossaEquipe/NossaEquipeService.js"));

            bundles.Add(new ScriptBundle("~/bundles/Servicos").Include(
                "~/Scripts/js/SAP/Servicos/ServicosController.js",
                "~/Scripts/js/SAP/Servicos/ServicosService.js",
                "~/Scripts/js/SAP/Servicos/ServicosMobileController.js",
                "~/Scripts/js/SAP/Servicos/EspecialidadeController.js"));

            bundles.Add(new ScriptBundle("~/bundles/Parceiros").Include(
                "~/Scripts/js/SAP/Parceiros/ParceirosController.js",
                "~/Scripts/js/SAP/Parceiros/ParceirosService.js"));

            bundles.Add(new ScriptBundle("~/bundles/PergunteEspecialista").Include(
                "~/Scripts/js/SAP/PergunteEspecialista/PergunteEspecialistaController.js",
                "~/Scripts/js/SAP/PergunteEspecialista/PergunteEspecialistaService.js"));
            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}
