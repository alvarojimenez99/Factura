using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factura.Models;

namespace Factura.Controllers
{
   
    public class ImpresorasController : Controller
    {
        // GET: Impresoras
        public enum Puertos
        {
            COM1,
            COM2,
            COM3,
            COM4,
            COM5,
            COM6,
            COM7,
            COM8
        }
        public ActionResult New()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "COM1", Value = "COM1" });
            lst.Add(new SelectListItem() { Text = "COM2", Value = "COM2" });
            lst.Add(new SelectListItem() { Text = "COM3", Value = "COM3" });
            lst.Add(new SelectListItem() { Text = "COM4", Value = "COM4" });
            lst.Add(new SelectListItem() { Text = "COM5", Value = "COM5" });
            lst.Add(new SelectListItem() { Text = "COM6", Value = "COM6" });
            lst.Add(new SelectListItem() { Text = "COM7", Value = "COM7" });
            

            ViewBag.Opciones = lst;
            return View();

        }
        [HttpPost]
        public ActionResult Registrar(Factura.Models.impresoras impresoraModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (
                    ffeEntitiesImpresora db = new ffeEntitiesImpresora())
                    {
                        DateTime now = DateTime.Now;
                        impresoraModel.created_at = now;
                        impresoraModel.estatus = 1;
                        db.impresoras.Add(impresoraModel);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Impresoras");
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }
        public ActionResult Index(Factura.Models.impresoras impresoraModel)
        {
            using (ffeEntitiesImpresora db = new ffeEntitiesImpresora()
               )
            {
                var impresoras = db.impresoras.Where(x => x.estatus != 0).Select(row => row).ToList();
                ViewBag.Data = impresoras;
                return View("Index");
            }
            
        }
    }
}