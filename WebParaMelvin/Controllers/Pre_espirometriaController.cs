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
    public class Pre_espirometriaController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Pre_espirometria
        public ActionResult Index()
        {
            var pre_espirometria = db.Pre_espirometria.Include(p => p.Formulario_S_O);
            return View(pre_espirometria.ToList());
        }

        // GET: Pre_espirometria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pre_espirometria pre_espirometria = db.Pre_espirometria.Find(id);
            if (pre_espirometria == null)
            {
                return HttpNotFound();
            }
            return View(pre_espirometria);
        }

        // GET: Pre_espirometria/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            
            return View();
        }

        // POST: Pre_espirometria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pre_espirometria,pulmon_torax_abdomen,infarto_al_corazon,retina_cirugia,problema_corazon,medicamento_tuberculosis,Esta_embarazada,Presion_arterial,infeccion_respirtatoria,medicamento_respiracion,cigarro_puro_pipa,ejercicio_fuerte,comida_completa,Comentarios")] Pre_espirometria pre_espirometria)
        {

            var fso = Session["FormSO"] as Formulario_S_O;
            pre_espirometria.Id_Formulario_S_O = fso.Id_Formulario_S_O;
            if (ModelState.IsValid)
            {
                db.Pre_espirometria.Add(pre_espirometria);
                db.SaveChanges();
                return RedirectToAction("Create", "Audiometrias");
            }

           
            return View(pre_espirometria);
        }

        // GET: Pre_espirometria/Edit/5
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
            Pre_espirometria pre_espirometria = db.Pre_espirometria.Find(id);
            if (pre_espirometria == null)
            {
                return HttpNotFound();
            }
            
            return View(pre_espirometria);
        }

        // POST: Pre_espirometria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pre_espirometria,pulmon_torax_abdomen,infarto_al_corazon,retina_cirugia,problema_corazon,medicamento_tuberculosis,Esta_embarazada,Presion_arterial,infeccion_respirtatoria,medicamento_respiracion,cigarro_puro_pipa,ejercicio_fuerte,comida_completa,pulmon_torax_abdomenA,infarto_al_corazonA,retina_cirugiaA,problema_corazonA,medicamento_tuberculosisA,Presion_arterialA,infeccion_respirtatoriaA,medicamento_respiracionA,cigarro_puro_pipaA,ejercicio_fuerteA,comida_completaA,Comentarios,Id_Formulario_S_O")] Pre_espirometria pre_espirometria)
        {
            if (ModelState.IsValid)
            {
                pre_espirometria.Modificado = true;
                var user = Session["User"] as Usuario;
                pre_espirometria.Usuario_que_modifico = user.Id_usuario;
                pre_espirometria.Ultima_modificacion = DateTime.Now;
                db.Entry(pre_espirometria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + pre_espirometria.Id_Formulario_S_O, "Formulario_S_O");
            }
            
            return View(pre_espirometria);
        }

        // GET: Pre_espirometria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pre_espirometria pre_espirometria = db.Pre_espirometria.Find(id);
            if (pre_espirometria == null)
            {
                return HttpNotFound();
            }
            return View(pre_espirometria);
        }

        // POST: Pre_espirometria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pre_espirometria pre_espirometria = db.Pre_espirometria.Find(id);
            db.Pre_espirometria.Remove(pre_espirometria);
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
