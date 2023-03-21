using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebParaMelvin.Models;

namespace WebParaMelvin.Controllers
{
    public class ArchivosExtrasController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: ArchivosExtras
        public ActionResult Index(int? id)
        {
            var archivosExtras = db.ArchivosExtras.Where(a => a.Id_Formulario_S_O == id);
            ViewBag.id = id;
            return View(archivosExtras.ToList().OrderBy(a => a.Descripcion));
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult SubirArchivos(FormCollection collection)
        {
            ArchivosExtra archivo = new ArchivosExtra();
            archivo.Id_Formulario_S_O = Convert.ToInt32(collection["data1"]);
            archivo.Descripcion = collection["data"].ToString();

            if (Request.Files.Count > 0)
            {
                string codigo = "";

                string[] fecha = DateTime.Now.ToShortDateString().Split('/');
                int hora = DateTime.Now.Hour;
                int minuto = DateTime.Now.Minute;
                int segundos = DateTime.Now.Second;
                int miliseg = DateTime.Now.Millisecond;
                codigo = fecha[0] + fecha[1] + fecha[2] + hora + minuto + segundos + miliseg;


                var file = Request.Files[0];

                var nombreArchivo = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Images/"), nombreArchivo.Insert(1, codigo));

                archivo.link = "../../Images/" + nombreArchivo.Insert(1, codigo);
                file.SaveAs(path);

                db.ArchivosExtras.Add(archivo);
                db.SaveChanges();
            }

            var archivosExtras = db.ArchivosExtras.Where(a => a.Id_Formulario_S_O == archivo.Id_Formulario_S_O);
            return View(archivosExtras.ToList());

        }

        // GET: ArchivosExtras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchivosExtra archivosExtra = db.ArchivosExtras.Find(id);
            if (archivosExtra == null)
            {
                return HttpNotFound();
            }
            return View(archivosExtra);
        }

        // GET: ArchivosExtras/Create
        public ActionResult Create()
        {
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado");
            return View();
        }

        // POST: ArchivosExtras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ArchivoExtra,Id_Formulario_S_O,Descripcion,link")] ArchivosExtra archivosExtra)
        {
            if (ModelState.IsValid)
            {
                db.ArchivosExtras.Add(archivosExtra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", archivosExtra.Id_Formulario_S_O);
            return View(archivosExtra);
        }

        // GET: ArchivosExtras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchivosExtra archivosExtra = db.ArchivosExtras.Find(id);
            if (archivosExtra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", archivosExtra.Id_Formulario_S_O);
            return View(archivosExtra);
        }

        // POST: ArchivosExtras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ArchivoExtra,Id_Formulario_S_O,Descripcion,link")] ArchivosExtra archivosExtra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archivosExtra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", archivosExtra.Id_Formulario_S_O);
            return View(archivosExtra);
        }

        // GET: ArchivosExtras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchivosExtra archivosExtra = db.ArchivosExtras.Find(id);
            if (archivosExtra == null)
            {
                return HttpNotFound();
            }
            return View(archivosExtra);
        }

        // POST: ArchivosExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArchivosExtra archivosExtra = db.ArchivosExtras.Find(id);
            int idFSO = archivosExtra.Id_Formulario_S_O.Value;
            string[] datos = archivosExtra.link.Split('/');

            FileInfo info = new FileInfo(Server.MapPath("/Images/"+datos[3]));
            info.Delete();
            db.ArchivosExtras.Remove(archivosExtra);
            db.SaveChanges();
            return RedirectToAction("Details/"+idFSO,"Formulario_S_O");
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
