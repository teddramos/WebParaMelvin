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
    public class UsuariosController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();
        private Utility functions = new Utility();

        // GET: Usuarios
        public ActionResult Index()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
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
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Session.Clear();
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //login...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Password")] Usuario usuario)
        {

            try
            {
                Session.Clear();

                var user = functions.login(usuario);
                if (user.id_rol == 1)
                {
                    Session["User"] = user;
                    return RedirectToAction("IndexEmpresa");
                    // return RedirectToAction("Create", "Formulario_S_O");
                }
                else if (user.id_rol == 2)
                {
                    Session["User"] = user;
                    return RedirectToAction("IndexEmpresa");
                    // return RedirectToAction("Create", "Formulario_S_O");
                }
                else if (user.id_rol == 4)
                {
                    Session["User"] = user;
                    return RedirectToAction("IndexEmpresa");
                    // return RedirectToAction("Create", "Formulario_S_O");
                }
                else
                 if (user.id_rol == 3)
                {
                    Session["User"] = user;
                    //return RedirectToAction("Index", "Formulario_S_O");
                    return RedirectToAction("IndexEmpresa");

                }
                else
                 if (user.id_rol == 5)
                {
                    ViewBag.Error = "Este Usuario esta Bloqueado,\n favor comunicarse con el administrador del Sistema.";
                    return View();
                }
                    return View();
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        //Action indexEmpresa
        public ActionResult IndexEmpresa()
        {
            return View();
        }
        public ActionResult ContatctoEmpresa()
        {
            return View();
        }
        public ActionResult VideoEmpresa()
        {
            return View();
        }
        // GET: Usuarios/Edit/5
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
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_rol = new SelectList(db.Rols, "Id_rol", "Descripcion", usuario.id_rol);
            
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_usuario,Email,Password,id_rol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as Usuario;
                usuario.Usuario_que_modifico = user.Id_usuario;
                usuario.Ultima_modificacion = DateTime.Now;
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_rol = new SelectList(db.Rols, "Id_rol", "Descripcion", usuario.id_rol);
            
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
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
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            try
            {
                db.SaveChanges();
            }
            catch {
                return View("ErrorEliminar");
            }
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
        // GET: Usuarios/NewUser
        public ActionResult NewUser()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            ViewBag.Id_rol = new SelectList(db.Rols, "Id_rol", "Descripcion");
            return View();
        }

        // POST: Usuarios/NewUser
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser([Bind(Include = "Id_usuario,Email,Password,id_rol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_rol = new SelectList(db.Rols, "Id_rol", "Descripcion", usuario.id_rol);
            return View(usuario);
        }
    }
}
