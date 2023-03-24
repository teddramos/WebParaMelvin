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
    public class Info_generalController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Info_general
        public ActionResult Index()
        {
            var info_general = db.Info_general.Include(i => i.Formulario_S_O);
            return View(info_general.ToList());
        }

        // GET: Info_general/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info_general info_general = db.Info_general.Find(id);
            if (info_general == null)
            {
                return HttpNotFound();
            }
            return View(info_general);
        }

        // GET: Info_general/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
           
            return View();
        }

        // POST: Info_general/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fecha,Departamento,Posicion,Tipo_de_evaluacion,Nombre,Sexo,Cedula,Fecha_de_nacimiento,Edad,Id_Empleado,Apellido,Pre_espirometria,Espirometria,Audiometria,Capacidad_fisica,Laboratorio,Radiografia,Hemografia,EKG,Examen_visual,Bateria_de_un_mes,Bateria_Completa,Historia_clinica_y_examen_fisico")] Info_general info_general)

        {
            var fso = Session["FormSO"] as Formulario_S_O;
            info_general.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (ModelState.IsValid)
            {
                db.Info_general.Add(info_general);
                db.SaveChanges();
                Session["InfoGeneral"] = info_general;
                return RedirectToAction("Create", "CSOes");
            }

            
            return View(info_general);
        }

        // GET: Info_general/Edit/5
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
            Info_general info_general = db.Info_general.Find(id);
            if (info_general == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Id_Formulario_S_O", info_general.Id_Formulario_S_O);
            return View(info_general);
        }

        // POST: Info_general/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Info_General,Empresa,Fecha,Departamento,Posicion,Tipo_de_evaluacion,Nombre,Sexo,Cedula,Fecha_de_nacimiento,Edad,Id_Empleado,Id_Formulario_S_O,Apellido,Pre_espirometria,Espirometria,Audiometria,Capacidad_fisica,Laboratorio,Radiografia,Hemografia,EKG,Examen_visual,Bateria_de_un_mes,Bateria_Completa,Historia_clinica_y_examen_fisico")] Info_general info_general)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as Usuario;
                info_general.Usuario_que_modifico = user.Id_usuario;
                info_general.Ultima_modificacion = DateTime.Now;
                db.Entry(info_general).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + info_general.Id_Formulario_S_O, "Formulario_S_O");
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Id_Formulario_S_O", info_general.Id_Formulario_S_O);
            return View(info_general);
        }

        // GET: Info_general/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info_general info_general = db.Info_general.Find(id);
            if (info_general == null)
            {
                return HttpNotFound();
            }
            return View(info_general);
        }

        // POST: Info_general/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Info_general info_general = db.Info_general.Find(id);
            db.Info_general.Remove(info_general);
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
