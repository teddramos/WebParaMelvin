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
    public class EKGsController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: EKGs
        public ActionResult Index()
        {
            var eKG = db.EKGs.Include(e => e.Formulario_S_O);
            return View(eKG.ToList());
        }

        // GET: EKGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EKG eKG = db.EKGs.Find(id);
            if (eKG == null)
            {
                return HttpNotFound();
            }
            return View(eKG);
        }

        // GET: EKGs/Create
        public ActionResult Create()
        {
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Id_Formulario_S_O");
            return View();
        }

        // POST: EKGs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( EKG eKG)
        {

            try
            {
                
                eKG.Archivo = new byte[eKG.Data.InputStream.Length];
                eKG.Data.InputStream.Read(eKG.Archivo, 0, eKG.Archivo.Length);
            }
            catch (Exception)
            {

            }

                if (ModelState.IsValid)
            {
                db.EKGs.Add(eKG);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            


            return View(eKG);
        }

        // GET: EKGs/Edit/5
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
            EKG eKG = db.EKGs.Find(id);
            if (eKG == null)
            {
                return HttpNotFound();
            }
           
            return View(eKG);
        }

        // POST: EKGs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EKG eKG)
        {
            if (eKG.Data != null)
            {
                eKG.Archivo = new byte[eKG.Data.InputStream.Length];
                eKG.Data.InputStream.Read(eKG.Archivo, 0, eKG.Archivo.Length);
                
            }
            if (ModelState.IsValid)
            {
                var user = Session["User"] as Usuario;
                eKG.Usuario_que_modifico = user.Id_usuario;
                eKG.Ultima_modificacion = DateTime.Now;
                eKG.Modificado = true;
                db.Entry(eKG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + eKG.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(eKG);
        }

        // GET: EKGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EKG eKG = db.EKGs.Find(id);
            if (eKG == null)
            {
                return HttpNotFound();
            }
            return View(eKG);
        }

        // POST: EKGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EKG eKG = db.EKGs.Find(id);
            db.EKGs.Remove(eKG);
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
