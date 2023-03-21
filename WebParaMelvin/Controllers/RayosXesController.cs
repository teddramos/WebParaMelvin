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
    public class RayosXesController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: RayosXes
        public ActionResult Index()
        {
            var rayosX = db.RayosXes.Include(r => r.Formulario_S_O);
            return View(rayosX.ToList());
        }

        // GET: RayosXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RayosX rayosX = db.RayosXes.Find(id);
            if (rayosX == null)
            {
                return HttpNotFound();
            }
            return View(rayosX);
        }

        // GET: RayosXes/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View();
        }

        // POST: RayosXes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RayosX rayosX)
        {
           

            var fso = Session["FormSO"] as Formulario_S_O;

            rayosX.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (ModelState.IsValid)
            {
                db.RayosXes.Add(rayosX);
                db.SaveChanges();
                return RedirectToAction("Create", "Consentimiento_Informado");
            }

           
            return View(rayosX);
        }

        // GET: RayosXes/Edit/5
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
            RayosX rayosX = db.RayosXes.Find(id);
            if (rayosX == null)
            {
                return HttpNotFound();
            }
            
            return View(rayosX);
        }

        // POST: RayosXes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RayosX rayosX)
        {
            if (rayosX.Archivo != null) 
            {
                rayosX.Firma = new byte[rayosX.Archivo.InputStream.Length];
                rayosX.Archivo.InputStream.Read(rayosX.Firma, 0, rayosX.Firma.Length);

                
            }
            if(rayosX.Archivo2 != null) { 
            rayosX.Firma2 = new byte[rayosX.Archivo2.InputStream.Length];
                rayosX.Archivo2.InputStream.Read(rayosX.Firma2, 0, rayosX.Firma2.Length);
            }
            if (ModelState.IsValid)
            {
                var user = Session["User"] as Usuario;
                rayosX.Usuario_que_modifico = user.Id_usuario;
                rayosX.Ultima_modificacion = DateTime.Now;
                rayosX.Modificado = true;
                db.Entry(rayosX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + rayosX.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(rayosX);
        }

        // GET: RayosXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RayosX rayosX = db.RayosXes.Find(id);
            if (rayosX == null)
            {
                return HttpNotFound();
            }
            return View(rayosX);
        }

        // POST: RayosXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RayosX rayosX = db.RayosXes.Find(id);
            db.RayosXes.Remove(rayosX);
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
