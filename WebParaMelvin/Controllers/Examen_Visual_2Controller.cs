using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebParaMelvin.Models;

namespace WebParaMelvin.Controllers
{
    public class Examen_Visual_2Controller : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Examen_Visual_2
        public ActionResult Index()
        {
            var examen_Visual_2 = db.Examen_Visual_2.Include(e => e.Formulario_S_O);
            return View(examen_Visual_2.ToList());
        }

        // GET: Examen_Visual_2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_Visual_2 examen_Visual_2 = db.Examen_Visual_2.Find(id);
            if (examen_Visual_2 == null)
            {
                return HttpNotFound();
            }
            return View(examen_Visual_2);
        }

        // GET: Examen_Visual_2/Create
        public ActionResult Create()
        {
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado");
            return View();
        }

        // POST: Examen_Visual_2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Examen_Visual_2,Archivo,Id_Formulario_S_O,Modificado,Ultima_modificacion,Usuario_que_modifico,Estado")] Examen_Visual_2 examen_Visual_2)
        {
            if (ModelState.IsValid)
            {
                db.Examen_Visual_2.Add(examen_Visual_2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", examen_Visual_2.Id_Formulario_S_O);
            return View(examen_Visual_2);
        }

        // GET: Examen_Visual_2/Edit/5
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
            Examen_Visual_2 examen_Visual_2 = db.Examen_Visual_2.Find(id);
            if (examen_Visual_2 == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", examen_Visual_2.Id_Formulario_S_O);
            return View(examen_Visual_2);
        }

        // POST: Examen_Visual_2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Examen_Visual_2 examen_Visual_2)
        {
            if (examen_Visual_2.Data != null)
            {
                examen_Visual_2.Archivo = new byte[examen_Visual_2.Data.InputStream.Length];
                examen_Visual_2.Data.InputStream.Read(examen_Visual_2.Archivo, 0, examen_Visual_2.Archivo.Length);
            }
            if (ModelState.IsValid)
            {
                examen_Visual_2.Modificado = true;
                var user = Session["User"] as Usuario;
                examen_Visual_2.Usuario_que_modifico = user.Id_usuario;
                examen_Visual_2.Ultima_modificacion = DateTime.Now;

                if (examen_Visual_2.Estado == "Finalizada" && examen_Visual_2.Firmar)
                {
                    examen_Visual_2.Firma = user.Firma;
                }

                db.Entry(examen_Visual_2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + examen_Visual_2.Id_Formulario_S_O, "Formulario_S_O");
            }
            return View(examen_Visual_2);
        }

        // GET: Examen_Visual_2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_Visual_2 examen_Visual_2 = db.Examen_Visual_2.Find(id);
            if (examen_Visual_2 == null)
            {
                return HttpNotFound();
            }
            return View(examen_Visual_2);
        }

        // POST: Examen_Visual_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examen_Visual_2 examen_Visual_2 = db.Examen_Visual_2.Find(id);
            db.Examen_Visual_2.Remove(examen_Visual_2);
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
