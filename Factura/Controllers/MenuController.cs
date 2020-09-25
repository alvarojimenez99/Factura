using Factura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Factura.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
       
        public ActionResult Inicio(Factura.Models.facturas facturaModel)
        {
            using (ffeEntitiesFactura db = new ffeEntitiesFactura()
                )
            {
                var empresaDetails = db.facturas.Where(x => x.estatus != 0).Where(x => x.tipo == 1).Select(row => row).ToList();
                ViewBag.Data = empresaDetails;
                return View("Inicio");
            }

        }
        public ActionResult FacturasFisicas(Factura.Models.facturas facturaModel)
        {
            try
            {
                HttpContext.Response.Headers.Add("refresh", "10; url=" + Url.Action("FacturasFisicas"));

                // ffeEntitiesEmpresa dbempresa = new ffeEntitiesEmpresa();
                //ffeEntitiesFactura db_2 = new ffeEntitiesFactura();
                /*var facturas3 = db_2
                                            .facturas
                                            .Where(x => x.estatus != 0)
                                            .Where(x => x.tipo == 2)
                                            .Join(dbempresa.empresas,
                                            factura1 => factura1.empresa_id,
                                            empresas1 => empresas1.id,
                                            (factura1, empresas1) => new { factura1.cliente, factura1.direccion, factura1.ruc, empresas1.name, factura1.fecha, factura1.estatus }
                                            ).ToList();*/
                /*IQueryable facturas2 = from a in db_2.facturas
                           join b in dbempresa.empresas
                           on a.empresa_id equals b.id
                           where ((a.estatus != 0) && (a.tipo == 2))
                           select new { cliente = a.cliente, direccion = b.direccion, ruc = a.ruc, empresa = b.name, fecha = a.fecha, estatus = a.estatus };
                */
                using (ffeEntitiesFactura db = new ffeEntitiesFactura()
                )
            {
                    var facturas = db
                                            .facturas
                                            .Where(x => x.estatus != 0)
                                            .Where(x => x.tipo == 2).Select(row => row).ToList();


                    /**/
                    /* IQueryable facturas2 =  from    a   in  db.facturas
                                 join    b   in  dbempresa.empresas 
                                 on      a.empresa_id equals b.id
                                 where    ((a.estatus != 0) && (a.tipo == 2))
                                 select new { cliente = a.cliente, direccion = b.direccion, ruc = a.ruc, empresa = b.name, fecha = a.fecha, estatus = a.estatus };*/
                    ViewBag.Data = facturas;
                    return View("FacturasFisicas");
            }
            }
            catch(Exception ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }

        }
    }
}