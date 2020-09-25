using Factura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Factura.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FacturaInfo()
        {
            FacturaDatos elemento = new FacturaDatos()
            
            {
                FacturaId = 1001,
                Monto= 1500,
                Impuesto=10,
                Fecha= Convert.ToDateTime("18/08/2020")
                
            };


            return View(elemento);
        }
    }
}