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
    public class EspirometriasController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Espirometrias
        public ActionResult Index()
        {
            var espirometria = db.Espirometrias.Include(e => e.Formulario_S_O);
            return View(espirometria.ToList());
        }

        // GET: Espirometrias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espirometria espirometria = db.Espirometrias.Find(id);
            if (espirometria == null)
            {
                return HttpNotFound();
            }
            return View(espirometria);
        }

        // GET: Espirometrias/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            
            return View();
        }

        // POST: Espirometrias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Espirometria espirometria)
        {
            Espirometria espe = new Espirometria();

            var fso = Session["FormSO"] as Formulario_S_O;

            try
            {
                espe.Id_Formulario_S_O = fso.Id_Formulario_S_O;
                espe.Archivo = new byte[espirometria.Firma.InputStream.Length];
                espirometria.Firma.InputStream.Read(espe.Archivo, 0, espe.Archivo.Length);

            }
            catch (Exception)
            {

            }



            if (ModelState.IsValid)
            {
                db.Espirometrias.Add(espe);
                db.SaveChanges();
                return RedirectToAction("Create", "RayosXes");
            }

            
            return View(espirometria);
        }

        // GET: Espirometrias/Edit/5
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
            Espirometria espirometria = db.Espirometrias.Find(id);
            if (espirometria == null)
            {
                return HttpNotFound();
            }
           
            return View(espirometria);
        }

        // POST: Espirometrias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Espirometria espirometria)
        {
           

            try
            {
                if(espirometria.Firma != null) { 

                espirometria.Archivo = new byte[espirometria.Firma.InputStream.Length];
                espirometria.Firma.InputStream.Read(espirometria.Archivo, 0, espirometria.Archivo.Length);
                }

            }
            catch (Exception)
            {

            }
            if (ModelState.IsValid)
            {
                espirometria.Modificado = true;
                var user = Session["User"] as Usuario;
                espirometria.Usuario_que_modifico = user.Id_usuario;
                espirometria.Ultima_modificacion = DateTime.Now;
                db.Entry(espirometria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + espirometria.Id_Formulario_S_O, "Formulario_S_O");
            }
           
            return View(espirometria);
        }

        // GET: Espirometrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espirometria espirometria = db.Espirometrias.Find(id);
            if (espirometria == null)
            {
                return HttpNotFound();
            }
            return View(espirometria);
        }

        // POST: Espirometrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Espirometria espirometria = db.Espirometrias.Find(id);
            db.Espirometrias.Remove(espirometria);
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
