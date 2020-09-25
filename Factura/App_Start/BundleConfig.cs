using System.Web;
using System.Web.Optimization;

namespace Factura
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
         

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
                    bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Content/css/fuente.css",
                "~/Content/css/sb-admin-2.min.css",
                "~/Content/vendor/datatables/dataTables.bootstrap4.min.css"));
           
   
               bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/js/sb-admin-2.min.js",
                "~/Content/vendor/datatables/jquery.dataTables.min.js",
                "~/Content/vendor/datatables/dataTables.bootstrap4.min.js",
                "~/Content/js/demo/datatables-demo.js"));

        }
    }
}
