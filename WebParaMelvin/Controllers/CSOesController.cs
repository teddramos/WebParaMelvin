using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using WebParaMelvin.Models;

namespace WebParaMelvin.Controllers
{
    public class CSOesController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: CSOes
        public ActionResult Index()
        {
            var cSO = db.CSOes.Include(c => c.Formulario_S_O);
            return View(cSO.ToList());
        }

        // GET: CSOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSO cSO = db.CSOes.Find(id);
            if (cSO == null)
            {
                return HttpNotFound();
            }
            return View(cSO);
        }

        // GET: CSOes/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }

            return View();
        }

        // POST: CSOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CSO cSO)
        {
            var fso = Session["FormSO"] as Formulario_S_O;
            cSO.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (cSO.Archivo != null)
            {
                cSO.Firma = new byte[cSO.Archivo.InputStream.Length];
                cSO.Archivo.InputStream.Read(cSO.Firma, 0, cSO.Firma.Length);
            }

            
            if (ModelState.IsValid)
            {
                db.CSOes.Add(cSO);
                db.Historia_Clinica.Add(new Historia_Clinica()
                {
                    Id_Formulario_S_O = cSO.Id_Formulario_S_O
                });
                db.Pre_espirometria.Add(new Pre_espirometria() {
                    Id_Formulario_S_O = cSO.Id_Formulario_S_O
                });
                db.Audiometrias.Add(new Audiometria() {
                    Id_Formulario_S_O = cSO.Id_Formulario_S_O
                });
                db.Examen_Visual.Add(new Examen_Visual() {
                    Id_Formulario_S_O=cSO.Id_Formulario_S_O 
                });
                db.Mareos.Add(new Mareo() {
                    Id_Formulario_S_O = cSO.Id_Formulario_S_O
                });
                db.Hemogramas.Add(new Hemograma() {
                    Id_Formulario_S_O=cSO.Id_Formulario_S_O
                });
                db.Laboratorios.Add(new Laboratorio() {
                    Id_Formulario_S_O=cSO.Id_Formulario_S_O
                });
                db.Espirometrias.Add(new Espirometria() {
                    Id_Formulario_S_O=cSO.Id_Formulario_S_O
                });
                db.RayosXes.Add(new RayosX() {
                    Id_Formulario_S_O =cSO.Id_Formulario_S_O
                });
                db.Consentimiento_Informado.Add(new Consentimiento_Informado()
                {
                    Id_Formulario_S_O = cSO.Id_Formulario_S_O
                });
                db.EKGs.Add(new EKG() {
                    Id_Formulario_S_O = cSO.Id_Formulario_S_O
                });
                cSO.Usuario_que_modifico =(Session["User"] as Usuario).Id_usuario;
                db.SaveChanges();
                return RedirectToAction("Create", "Formulario_S_O");
            }

            
            return View(cSO);
        }

        // GET: CSOes/Edit/5
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
            CSO cSO = db.CSOes.Find(id);
            if (cSO == null)
            {
                return HttpNotFound();
            }
  
            return View(cSO);
        }

        // POST: CSOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CSO cSO)
        {
            if (cSO.Archivo != null)
            {
                cSO.Firma = new byte[cSO.Archivo.InputStream.Length];
                cSO.Archivo.InputStream.Read(cSO.Firma, 0, cSO.Firma.Length);
               
            }
            var user = Session["User"] as Usuario;
            cSO.Usuario_que_modifico = user.Id_usuario;
            cSO.Ultima_modificacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(cSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + cSO.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(cSO);
        }

        // GET: CSOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSO cSO = db.CSOes.Find(id);
            if (cSO == null)
            {
                return HttpNotFound();
            }
            return View(cSO);
        }

        // POST: CSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSO cSO = db.CSOes.Find(id);
            db.CSOes.Remove(cSO);
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
