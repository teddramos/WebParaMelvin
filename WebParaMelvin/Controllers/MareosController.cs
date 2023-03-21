using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebParaMelvin.Models;

namespace WebParaMelvin.Controllers
{
    public class MareosController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Mareos
        public ActionResult Index()
        {
            var mareo = db.Mareos.Include(m => m.Formulario_S_O);
            return View(mareo.ToList());
        }

        // GET: Mareos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mareo mareo = db.Mareos.Find(id);
            if (mareo == null)
            {
                return HttpNotFound();
            }
            return View(mareo);
        }

        // GET: Mareos/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            
            return View();
        }

        // POST: Mareos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mareo mareo)
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }

            if (mareo.Archivo != null)
            {
                mareo.Firma = new byte[mareo.Archivo.InputStream.Length];
                mareo.Archivo.InputStream.Read(mareo.Firma, 0, mareo.Firma.Length);
            }
            if (ModelState.IsValid)
            {
                db.Mareos.Add(mareo);
                db.SaveChanges();
                return RedirectToAction("Details/" + mareo.Id_Formulario_S_O, "Formulario_S_O");
            }

            
            return View(mareo);
        }

        // GET: Mareos/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mareo mareo = db.Mareos.Find(id);
            if (mareo == null)
            {
                return HttpNotFound();
            }
           
            return View(mareo);
        }

        // POST: Mareos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mareo mareo)
        {
            if (mareo.Archivo != null)
            {
                mareo.Firma = new byte[mareo.Archivo.InputStream.Length];
                mareo.Archivo.InputStream.Read(mareo.Firma, 0, mareo.Firma.Length);
            }
            if (ModelState.IsValid)
            {
                mareo.Modificado = true;
                var user = Session["User"] as Usuario;
                mareo.Usuario_que_modifico = user.Id_usuario;
                mareo.Ultima_modificacion = DateTime.Now;
                db.Entry(mareo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + mareo.Id_Formulario_S_O, "Formulario_S_O");
            }
           
            return View(mareo);
        }

        // GET: Mareos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mareo mareo = db.Mareos.Find(id);
            if (mareo == null)
            {
                return HttpNotFound();
            }
            return View(mareo);
        }

        // POST: Mareos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mareo mareo = db.Mareos.Find(id);
            db.Mareos.Remove(mareo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
