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
    public class Consentimiento_InformadoController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Consentimiento_Informado
        public ActionResult Index()
        {
            var consentimiento_Informado = db.Consentimiento_Informado.Include(c => c.Formulario_S_O);
            return View(consentimiento_Informado.ToList());
        }

        // GET: Consentimiento_Informado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consentimiento_Informado consentimiento_Informado = db.Consentimiento_Informado.Find(id);
            if (consentimiento_Informado == null)
            {
                return HttpNotFound();
            }
            return View(consentimiento_Informado);
        }

        // GET: Consentimiento_Informado/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View();
        }

        // POST: Consentimiento_Informado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consentimiento_Informado consentimiento_Informado)
        {
            Consentimiento_Informado cin = new Consentimiento_Informado();

            var fso = Session["FormSO"] as Formulario_S_O;

            //try
            //{
            //    cin.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            //    cin.Firma = new byte[consentimiento_Informado.Firma.InputStream.Length];
            //    consentimiento_Informado.Firma.InputStream.Read(cin.Firma, 0, cin.Firma.Length);
            //    cin.Huella = new byte[consentimiento_Informado.Huella.InputStream.Length];
            //    consentimiento_Informado.Huella.InputStream.Read(cin.Huella, 0, cin.Huella.Length);

            //}
            //catch (Exception)
            //{

            //}

            if (ModelState.IsValid)
            {
                db.Consentimiento_Informado.Add(cin);
                db.SaveChanges();
                return RedirectToAction("Create", "EKGs");
            }

            
            return View(consentimiento_Informado);
        }

        // GET: Consentimiento_Informado/Edit/5
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
            Consentimiento_Informado consentimiento_Informado = db.Consentimiento_Informado.Find(id);
            if (consentimiento_Informado == null)
            {
                return HttpNotFound();
            }
           
            return View(consentimiento_Informado);
        }

        // POST: Consentimiento_Informado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consentimiento_Informado consentimiento_Informado)
        {

            if (consentimiento_Informado.DataFirma != null)
            {
                consentimiento_Informado.Firma = new byte[consentimiento_Informado.DataFirma.InputStream.Length];
                consentimiento_Informado.DataFirma.InputStream.Read(consentimiento_Informado.Firma, 0, consentimiento_Informado.Firma.Length);
            }
            if (consentimiento_Informado.DataHuella != null)
            {
                consentimiento_Informado.Huella = new byte[consentimiento_Informado.DataHuella.InputStream.Length];
                consentimiento_Informado.DataHuella.InputStream.Read(consentimiento_Informado.Huella, 0, consentimiento_Informado.Huella.Length);
            }
            if (ModelState.IsValid)
            {
                consentimiento_Informado.Modificado = true;
                var user = Session["User"] as Usuario;
                consentimiento_Informado.Usuario_que_modifico = user.Id_usuario;
                consentimiento_Informado.Ultima_modificacion = DateTime.Now;
                db.Entry(consentimiento_Informado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + consentimiento_Informado.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(consentimiento_Informado);
        }

        // GET: Consentimiento_Informado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consentimiento_Informado consentimiento_Informado = db.Consentimiento_Informado.Find(id);
            if (consentimiento_Informado == null)
            {
                return HttpNotFound();
            }
            return View(consentimiento_Informado);
        }

        // POST: Consentimiento_Informado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consentimiento_Informado consentimiento_Informado = db.Consentimiento_Informado.Find(id);
            db.Consentimiento_Informado.Remove(consentimiento_Informado);
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
