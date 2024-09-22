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
    public class EpWorthsController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: EpWorths
        public ActionResult Index()
        {
            var epWorths = db.EpWorths.Include(e => e.Formulario_S_O);
            return View(epWorths.ToList());
        }

        // GET: EpWorths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EpWorth epWorth = db.EpWorths.Find(id);
            if (epWorth == null)
            {
                return HttpNotFound();
            }
            return View(epWorth);
        }

        // GET: EpWorths/Create
        public ActionResult Create()
        {
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado");
            return View();
        }

        // POST: EpWorths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_EpWorth,sentado_y_leyendo,viendo_la_television,sentado_inactivo_lugar_publico,sentado_una_hora_pasajero,tumbado_de_tarde_para_descansar,sentado_hablando_con_otro,sentado_tranquilo_despues_de_comida,sentado_en_coche_por_unos_minutos_por_atasco,Modificado,Ultima_modificacion,Usuario_que_modifico,Estado,Id_Formulario_S_O")] EpWorth epWorth)
        {
            if (ModelState.IsValid)
            {
                db.EpWorths.Add(epWorth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", epWorth.Id_Formulario_S_O);
            return View(epWorth);
        }

        // GET: EpWorths/Edit/5
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
            EpWorth epWorth = db.EpWorths.Find(id);
            if (epWorth == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", epWorth.Id_Formulario_S_O);
            return View(epWorth);
        }

        // POST: EpWorths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EpWorth epWorth)
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }

            if (ModelState.IsValid)
            {
                epWorth.Modificado = true;
                
                epWorth.Usuario_que_modifico = user.Id_usuario;
                epWorth.Ultima_modificacion = DateTime.Now;

                if (epWorth.Estado == "Finalizada" && epWorth.Firmar)
                {
                    epWorth.Firma = user.Firma;
                }
                if (epWorth.Archivo != null)
                {
                    epWorth.firma_candidato = new byte[epWorth.Archivo.ContentLength];
                    epWorth.Archivo.InputStream.Read(epWorth.firma_candidato, 0,epWorth.firma_candidato.Length);
                }
                else if( !string.IsNullOrEmpty(epWorth.sigImageData))
                {
                    epWorth.firma_candidato = Convert.FromBase64String( epWorth.sigImageData);
                  
                }
                //if (epWorth.Firmar)
                //{
                //    epWorth.Firma = user.Firma;
                //}

                db.Entry(epWorth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + epWorth.Id_Formulario_S_O, "Formulario_S_O");
            }
          
            return View(epWorth);
        }

        // GET: EpWorths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EpWorth epWorth = db.EpWorths.Find(id);
            if (epWorth == null)
            {
                return HttpNotFound();
            }
            return View(epWorth);
        }

        // POST: EpWorths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EpWorth epWorth = db.EpWorths.Find(id);
            db.EpWorths.Remove(epWorth);
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
