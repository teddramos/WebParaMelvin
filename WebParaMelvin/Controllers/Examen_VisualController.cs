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
    public class Examen_VisualController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Examen_Visual
        public ActionResult Index()
        {
            var examen_Visual = db.Examen_Visual.Include(e => e.Formulario_S_O);
            return View(examen_Visual.ToList());
        }

        // GET: Examen_Visual/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_Visual examen_Visual = db.Examen_Visual.Find(id);
            if (examen_Visual == null)
            {
                return HttpNotFound();
            }
            return View(examen_Visual);
        }

        // GET: Examen_Visual/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View();
        }

        // POST: Examen_Visual/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Examen_Visual examen_Visual)
        {

            
            if (examen_Visual.Archivo != null)
            {
                examen_Visual.Firma = new byte[examen_Visual.Archivo.InputStream.Length];
                examen_Visual.Archivo.InputStream.Read(examen_Visual.Firma, 0, examen_Visual.Firma.Length);

            }
            if (ModelState.IsValid)
            {
                db.Examen_Visual.Add(examen_Visual);
                db.SaveChanges();
                return RedirectToAction("Create","Mareos");
            }

           
            return View(examen_Visual);
        }

        // GET: Examen_Visual/Edit/5
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
            Examen_Visual examen_Visual = db.Examen_Visual.Find(id);
            if (examen_Visual == null)
            {
                return HttpNotFound();
            }
           
            return View(examen_Visual);
        }

        // POST: Examen_Visual/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Examen_Visual examen_Visual)
        {
            if (examen_Visual.Archivo != null)
            {
                examen_Visual.Firma = new byte[examen_Visual.Archivo.InputStream.Length];
                examen_Visual.Archivo.InputStream.Read(examen_Visual.Firma, 0, examen_Visual.Firma.Length);
            }
            if (ModelState.IsValid)
            {
                var user = Session["User"] as Usuario;
                examen_Visual.Usuario_que_modifico = user.Id_usuario;
                examen_Visual.Ultima_modificacion = DateTime.Now;
                examen_Visual.Modificado = true;
                db.Entry(examen_Visual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + examen_Visual.Id_Formulario_S_O, "Formulario_S_O");
            }
           
            return View(examen_Visual);
        }

        // GET: Examen_Visual/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_Visual examen_Visual = db.Examen_Visual.Find(id);
            if (examen_Visual == null)
            {
                return HttpNotFound();
            }
            return View(examen_Visual);
        }

        // POST: Examen_Visual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examen_Visual examen_Visual = db.Examen_Visual.Find(id);
            db.Examen_Visual.Remove(examen_Visual);
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
