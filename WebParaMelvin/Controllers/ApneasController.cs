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
    public class ApneasController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

        // GET: Apneas
        public ActionResult Index()
        {
            var apneas = db.Apneas.Include(a => a.Formulario_S_O);
            return View(apneas.ToList());
        }

        // GET: Apneas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apnea apnea = db.Apneas.Find(id);
            if (apnea == null)
            {
                return HttpNotFound();
            }
            return View(apnea);
        }

        // GET: Apneas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado");
            return View();
        }

        // POST: Apneas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Apnea,Tipo_licencia,Trabaja_de_noche,Dias_trabajo,Dias_descanso,Apnea_del_sueno,Ultimo_control,HTA,Medicacion,Polisomnografía_PSG,Fecha_ultima_PSG,En_mina,Fuera_de_mina,Se_cabeceo,Accidente_en_ultimas_5_horas,Ausencia_de_evidencia_de_maniobra,Colision_frontal_del_vehiculo,Vehiculo_que_invadio,El_conductor_no_recuerda,El_conductor_tomo_una_medicacion,El_conductor_se_encontraba_en_horas_extras,Accidente_por_somnolencia,Accidente_con_alta_sospecha,Accidente_con_escasa_evidencia,No_se_dispone_de_datos_suficientes,Accidente_no_debido_a_somnolencia,Su_esposa_comento_que_ronca,Su_esposa_comento_que_hace_ruidos,Su_esposa_comento_que_deja_de_respirar,Siente_mas_que_tiene_mas_sueno,Tiene_familiar_con_apnea,Accidente_por_falla_humana,Recibe_tratamiento_para_apnea,Se_le_ha_relizado_una_PSG,Puntuacion_epwhorth,Peso,Talla,IMC,Varon_normal,Mujer_normal,Sistolica,Diastolica,HTA_nueva,Grado,Excesiva_somnolencia,Antecendente_de_SAS,Historia_de_higiene,Cumple_con_dos_o_mas,Evaluacion_via_aerea,Apto_para_conducir_vehiculos,Firma,Id_Formulario_S_O,Modificado,Ultima_modificacion,Usuario_que_modifico,Estado")] Apnea apnea)
        {
            if (ModelState.IsValid)
            {
                db.Apneas.Add(apnea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", apnea.Id_Formulario_S_O);
            return View(apnea);
        }

        // GET: Apneas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apnea apnea = db.Apneas.Find(id);
            if (apnea == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", apnea.Id_Formulario_S_O);
            return View(apnea);
        }

        // POST: Apneas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Apnea,Tipo_licencia,Trabaja_de_noche,Dias_trabajo,Dias_descanso,Apnea_del_sueno,Ultimo_control,HTA,Medicacion,Polisomnografía_PSG,Fecha_ultima_PSG,En_mina,Fuera_de_mina,Se_cabeceo,Accidente_en_ultimas_5_horas,Ausencia_de_evidencia_de_maniobra,Colision_frontal_del_vehiculo,Vehiculo_que_invadio,El_conductor_no_recuerda,El_conductor_tomo_una_medicacion,El_conductor_se_encontraba_en_horas_extras,Accidente_por_somnolencia,Accidente_con_alta_sospecha,Accidente_con_escasa_evidencia,No_se_dispone_de_datos_suficientes,Accidente_no_debido_a_somnolencia,Su_esposa_comento_que_ronca,Su_esposa_comento_que_hace_ruidos,Su_esposa_comento_que_deja_de_respirar,Siente_mas_que_tiene_mas_sueno,Tiene_familiar_con_apnea,Accidente_por_falla_humana,Recibe_tratamiento_para_apnea,Se_le_ha_relizado_una_PSG,Puntuacion_epwhorth,Peso,Talla,IMC,Varon_normal,Mujer_normal,Sistolica,Diastolica,HTA_nueva,Grado,Excesiva_somnolencia,Antecendente_de_SAS,Historia_de_higiene,Cumple_con_dos_o_mas,Evaluacion_via_aerea,Apto_para_conducir_vehiculos,Firma,Id_Formulario_S_O,Modificado,Ultima_modificacion,Usuario_que_modifico,Estado")] Apnea apnea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apnea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Formulario_S_O = new SelectList(db.Formulario_S_O, "Id_Formulario_S_O", "Estado", apnea.Id_Formulario_S_O);
            return View(apnea);
        }

        // GET: Apneas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apnea apnea = db.Apneas.Find(id);
            if (apnea == null)
            {
                return HttpNotFound();
            }
            return View(apnea);
        }

        // POST: Apneas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apnea apnea = db.Apneas.Find(id);
            db.Apneas.Remove(apnea);
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
