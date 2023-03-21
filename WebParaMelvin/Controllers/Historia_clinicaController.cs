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
    public class Historia_ClinicaController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Historia_Clinica
        public ActionResult Index()
        {
            var Historia_Clinica = db.Historia_Clinica.Include(h => h.Formulario_S_O);
            return View(Historia_Clinica.ToList());
        }

        // GET: Historia_Clinica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia_Clinica Historia_Clinica = db.Historia_Clinica.Find(id);
            if (Historia_Clinica == null)
            {
                return HttpNotFound();
            }
            return View(Historia_Clinica);
        }

        // GET: Historia_Clinica/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
           
            return View();
        }

        // POST: Historia_Clinica/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Historia_Clinica Historia_Clinica)
        {


            var fso = Session["FormSO"] as Formulario_S_O;
            Historia_Clinica.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (Historia_Clinica.Archivo != null)
            {
                Historia_Clinica.Firma = new byte[Historia_Clinica.Archivo.InputStream.Length];
                Historia_Clinica.Archivo.InputStream.Read(Historia_Clinica.Firma, 0, Historia_Clinica.Firma.Length);
            }

            if (ModelState.IsValid)
            {
                db.Historia_Clinica.Add(Historia_Clinica);
                db.SaveChanges();
                return RedirectToAction("Create", "Pre_espirometria");
            }

           
            return View(Historia_Clinica);
        }

        // GET: Historia_Clinica/Edit/5
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
            Historia_Clinica Historia_Clinica = db.Historia_Clinica.Find(id);
            if (Historia_Clinica == null)
            {
                return HttpNotFound();
            }
        
            return View(Historia_Clinica);
        }

        // POST: Historia_Clinica/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Historia_Clinica Historia_Clinica)
        {
            if (Historia_Clinica.Archivo != null)
            {
                Historia_Clinica.Firma = new byte[Historia_Clinica.Archivo.InputStream.Length];
                Historia_Clinica.Archivo.InputStream.Read(Historia_Clinica.Firma, 0, Historia_Clinica.Firma.Length);
            }

            if (ModelState.IsValid)
            {
                Historia_Clinica.Modificado = true;
                var user = Session["User"] as Usuario;
                Historia_Clinica.Usuario_que_modifico = user.Id_usuario;
                Historia_Clinica.Ultima_modificacion = DateTime.Now;
                db.Entry(Historia_Clinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + Historia_Clinica.Id_Formulario_S_O, "Formulario_S_O");
            }
         
            return View(Historia_Clinica);
        }

        // GET: Historia_Clinica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia_Clinica Historia_Clinica = db.Historia_Clinica.Find(id);
            if (Historia_Clinica == null)
            {
                return HttpNotFound();
            }
            return View(Historia_Clinica);
        }

        // POST: Historia_Clinica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historia_Clinica Historia_Clinica = db.Historia_Clinica.Find(id);
            db.Historia_Clinica.Remove(Historia_Clinica);
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
