using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Factura.Models;
using WebGrease.Css.Ast.Selectors;

namespace Factura.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult List(Factura.Models.empresas empresaModel)
        {
            using (ffeEntities db = new ffeEntities())
            {
                var usuarios = db.users.Select(row => row).ToList();
                ViewBag.Data = usuarios;
                return View("List");
            }

        }
        [HttpPost]
        public ActionResult Actualizar(Factura.Models.users empresaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ffeEntities db = new ffeEntities())
                    {
                        var empresaDetails = db.users.Find(empresaModel.id);
                        if (TryUpdateModel(empresaDetails)) db.SaveChanges();
                    }
                }
                return RedirectToAction("List", "Login");
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
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
                using (ffeEntities db = new ffeEntities())
                {
                    var empresaDetails = db.users.Find(id);
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

        [HttpPost]
        public ActionResult Registrar(Factura.Models.users empresaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (
                    ffeEntities db = new ffeEntities())
                    {
                        DateTime now = DateTime.Now;
                        empresaModel.created_at = now;
                        empresaModel.active = 1;
                        db.users.Add(empresaModel);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("List", "Login");
            }
          catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }
        public ActionResult New()
        {
            return View();

        }
        public ActionResult Index()
        {
            
            Session.Abandon();
            return View();
        }
        [HttpGet]
        public ActionResult Desactivar(int? id)
        {
            using (
               ffeEntities db = new ffeEntities())
            {
                var empresaDetails = db.users.Find(id);
                empresaDetails.active = 0;
                if (TryUpdateModel(empresaDetails)) db.SaveChanges();
                return RedirectToAction("List", "Login");
            }

        }
        [HttpPost]
        public ActionResult Autherize(Factura.Models.users userModel)
        {
            
            using (ffeEntities db=new ffeEntities())
            {
                var userDetails = db.users.Where(x => x.email == userModel.email && x.password == userModel.password).FirstOrDefault();
                if(userDetails==null)
                {
                    userModel.LoginErrorMessage = " Username o password incorrectos.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userid"] = userDetails.id;
                    Session["username"] = userDetails.nombres;
                    Session["useremail"] = userDetails.email;
                    return RedirectToAction("Inicio", "Menu");
                }
            }
          

        }
    }
}