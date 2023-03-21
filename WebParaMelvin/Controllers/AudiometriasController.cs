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
    public class AudiometriasController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Audiometrias
        public ActionResult Index()
        {
            var audiometria = db.Audiometrias.Include(a => a.Formulario_S_O);
            return View(audiometria.ToList()); 
        }

        // GET: Audiometrias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiometria audiometria = db.Audiometrias.Find(id);
            if (audiometria == null)
            {
                return HttpNotFound();
            }
            return View(audiometria);
        }

        // GET: Audiometrias/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View();
            
        }

        // POST: Audiometrias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Audiometria audiometria)
        {

            var fso = Session["FormSO"] as Formulario_S_O;
            audiometria.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (audiometria.Archivo != null)
            {

                audiometria.Firma = new byte[audiometria.Archivo.InputStream.Length];
                audiometria.Archivo.InputStream.Read(audiometria.Firma, 0, audiometria.Firma.Length);
            }

            if (ModelState.IsValid)
            {
                db.Audiometrias.Add(audiometria);
                db.SaveChanges();
                return RedirectToAction("Create", "Examen_Visual");
            }

            
            return View(audiometria);
        }

        // GET: Audiometrias/Edit/5
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
            Audiometria audiometria = db.Audiometrias.Find(id);
            if (audiometria == null)
            {
                return HttpNotFound();
            }
           
            return View(audiometria);
        }

        // POST: Audiometrias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Audiometria audiometria)
        {
            if (audiometria.Archivo != null)
            {
                audiometria.Firma = new byte[audiometria.Archivo.InputStream.Length];
                audiometria.Archivo.InputStream.Read(audiometria.Firma, 0, audiometria.Firma.Length);
                var user = Session["User"] as Usuario;
                audiometria.Usuario_que_modifico = user.Id_usuario;
                audiometria.Ultima_modificacion = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                audiometria.Modificado = true;
                db.Entry(audiometria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + audiometria.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(audiometria);
        }

        // GET: Audiometrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiometria audiometria = db.Audiometrias.Find(id);
            if (audiometria == null)
            {
                return HttpNotFound();
            }
            return View(audiometria);
        }

        // POST: Audiometrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audiometria audiometria = db.Audiometrias.Find(id);
            db.Audiometrias.Remove(audiometria);
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
