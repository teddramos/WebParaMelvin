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
    public class HemogramasController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Hemogramas
        public ActionResult Index()
        {
            var hemograma = db.Hemogramas.Include(h => h.Formulario_S_O);
            return View(hemograma.ToList());
        }

        // GET: Hemogramas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hemograma hemograma = db.Hemogramas.Find(id);
            if (hemograma == null)
            {
                return HttpNotFound();
            }
            return View(hemograma);
        }

        // GET: Hemogramas/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View();
        }

        // POST: Hemogramas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hemograma hemograma)
        {
           

          
           
            try
            {
             
                hemograma.Archivo = new byte[hemograma.Data.InputStream.Length];
                hemograma.Data.InputStream.Read(hemograma.Archivo, 0, hemograma.Archivo.Length);
                
            }catch(Exception)
            {

            }
            if (ModelState.IsValid)
            {
                db.Hemogramas.Add(hemograma);
                db.SaveChanges();
                return RedirectToAction("Create","Laboratorios"); 
               
            }

            
            return View(hemograma);
        }

        // GET: Hemogramas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hemograma hemograma = db.Hemogramas.Find(id);
            if (hemograma == null)
            {
                return HttpNotFound();
            }
           
            return View(hemograma);
        }

        // POST: Hemogramas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Hemograma hemograma)
        {
            if (hemograma.Data != null)
            {
                hemograma.Archivo = new byte[hemograma.Data.InputStream.Length];
                hemograma.Data.InputStream.Read(hemograma.Archivo, 0, hemograma.Archivo.Length);
            }
            if (ModelState.IsValid)
            {
                hemograma.Modificado = true;
                var user = Session["User"] as Usuario;
                hemograma.Usuario_que_modifico = user.Id_usuario;
                hemograma.Ultima_modificacion = DateTime.Now;
                db.Entry(hemograma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + hemograma.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(hemograma);
        }

        // GET: Hemogramas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hemograma hemograma = db.Hemogramas.Find(id);
            if (hemograma == null)
            {
                return HttpNotFound();
            }
            return View(hemograma);
        }

        // POST: Hemogramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hemograma hemograma = db.Hemogramas.Find(id);
            db.Hemogramas.Remove(hemograma);
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
