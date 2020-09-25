using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Factura.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Factura.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index(Factura.Models.empresas empresaModel)
        {
            using (
                ffeEntitiesEmpresa db = new ffeEntitiesEmpresa())
                
            {
                var empresaDetails = db.empresas.Where(x => x.active == 1).Select(row => row).ToList();
                ViewBag.Data = empresaDetails;
                return View("Index");
            }

        }
     
        public ActionResult Crud(int? id)
        {
            try
            { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (ffeEntitiesEmpresa db = new ffeEntitiesEmpresa())
            {
                var empresaDetails =   db.empresas.Find(id);
                return View(empresaDetails);
            }
            }
            catch (Exception  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View();
            }

        }
        public ActionResult New()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Actualizar(Factura.Models.empresas empresaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ffeEntitiesEmpresa db = new ffeEntitiesEmpresa())
                        {
                        var empresaDetails = db.empresas.Find(empresaModel.id);
                        if (TryUpdateModel(empresaDetails))       db.SaveChanges();
                        }
                }
                return RedirectToAction("Index", "Empresa");
            }
            catch(Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Registrar(Factura.Models.empresas empresaModel)
        {
            try
            {
                if (ModelState.IsValid)
            {
                using (
                ffeEntitiesEmpresa db = new ffeEntitiesEmpresa())
                {
                    DateTime now = DateTime.Now;
                    empresaModel.created_at = now;
                        empresaModel.active=1;

                        db.empresas.Add(empresaModel);
                    db.SaveChanges();
                    }
            }
            return RedirectToAction("Index", "Empresa");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return null;
            }
            /*catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }*/
        }
        [HttpGet]
        public ActionResult Desactivar(int? id)
        {
            using (
                ffeEntitiesEmpresa db = new ffeEntitiesEmpresa())
            {
                var empresaDetails = db.empresas.Find(id);
                empresaDetails.active = 0;
                if (TryUpdateModel(empresaDetails)) db.SaveChanges();
                return RedirectToAction("Index", "Empresa");
            }

        }
    }
}