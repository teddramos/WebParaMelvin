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
    public class LaboratoriosController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Laboratorios
        public ActionResult Index()
        {
            var laboratorio = db.Laboratorios.Include(l => l.Formulario_S_O);
            return View(laboratorio.ToList());
        }

        // GET: Laboratorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // GET: Laboratorios/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View();
        }

        // POST: Laboratorios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Laboratorio laboratorio)
        {

            var fso = Session["FormSO"] as Formulario_S_O;
            laboratorio.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (laboratorio.Archivo != null)
            {
                laboratorio.firma = new byte[laboratorio.Archivo.InputStream.Length];
                laboratorio.Archivo.InputStream.Read(laboratorio.firma, 0, laboratorio.firma.Length);
            }

            if (ModelState.IsValid)
            {
                db.Laboratorios.Add(laboratorio);
                db.SaveChanges();
                return RedirectToAction("Create", "Espirometrias");
            }

            
            return View(laboratorio);
        }

        // GET: Laboratorios/Edit/5
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
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            
            return View(laboratorio);
        }

        // POST: Laboratorios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Laboratorio laboratorio)
        {
            if (laboratorio.Archivo != null )
            {
                laboratorio.firma = new byte[laboratorio.Archivo.InputStream.Length];
                laboratorio.Archivo.InputStream.Read(laboratorio.firma, 0, laboratorio.firma.Length);
                

            }
            if (laboratorio.Archivo1 != null)
            {
                laboratorio.Firma1 = new byte[laboratorio.Archivo1.InputStream.Length];
                laboratorio.Archivo1.InputStream.Read(laboratorio.Firma1, 0, laboratorio.Firma1.Length);
            }
            if (ModelState.IsValid)
            {
                laboratorio.Modificado = true;
                var user = Session["User"] as Usuario;
                laboratorio.Usuario_que_modifico = user.Id_usuario;
                laboratorio.Ultima_modificacion = DateTime.Now;
                db.Entry(laboratorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + laboratorio.Id_Formulario_S_O, "Formulario_S_O");
            }
           
            return View(laboratorio);
        }

        // GET: Laboratorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            db.Laboratorios.Remove(laboratorio);
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
