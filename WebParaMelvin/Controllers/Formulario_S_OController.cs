using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebParaMelvin.Models;
using Rotativa;
using System.IO;
using System.Net.Mail;
using System.Web.Http.Results;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebParaMelvin.Controllers
{
    public class  Formulario_S_OController : Controller
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();

       
        // GET: Formulario_S_O
        public ActionResult Index()
        {
            
             
            
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            if (Session.Count > 0)
            {
                user = Session["User"] as Usuario;
                if (user.id_rol == 3)
                {
                    try
                    {
                        var idempresa = db.Empresas.FirstOrDefault(a => a.Id_Usuario == user.Id_usuario).Id_Empresa;
                        var formulario_S_O = db.Formulario_S_O.Where(a => a.Id_Empresa == idempresa && a.Estado == "Visible");
                        return View(formulario_S_O.OrderByDescending(a => a.Id_Formulario_S_O).ToList());
                    }
                    catch
                    {

                    }
                        
                    
                }
                else
                {
                   // return View(db.Formulario_S_O.ToList().OrderByDescending(a => a.Id_Formulario_S_O).ToList());

                   return View(db.Formulario_S_O.ToList().OrderByDescending(a =>a.Id_Formulario_S_O).Take(30).ToList());
                }
            }
            return View();
        }
        // POST: Formulario_S_O
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult SearchIndex([Bind(Include = "data")] object data)
        {

            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            string[] vs = data as string[];
            if (Session.Count > 0)
            {
                user = Session["User"] as Usuario;
                if (user.id_rol == 3)
                {
                    try
                    {
                        List<Info_general> listInf = db.Info_general.ToList();
                        List<Info_general> listInfGG = new List<Info_general>();
                        foreach (var inf in listInf.ToList())
                        {
                            if (inf.Nombre.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()) || inf.Apellido.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()) || inf.Cedula.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()))
                            {
                                listInfGG.Add(inf);
                            }
                        }
                        List<Formulario_S_O> lista = new List<Formulario_S_O>();
                        foreach (var info in listInfGG)
                        {
                            var idempresa = db.Empresas.FirstOrDefault(a => a.Id_Usuario == user.Id_usuario).Id_Empresa;
                            var formulario_S_O = db.Formulario_S_O.Where(a => a.Id_Empresa == idempresa && a.Estado == "Visible");
                            var fsoGet = formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == info.Id_Formulario_S_O);
                            lista.Add(fsoGet);
                        }

                        if (lista.Count <= 0)
                        {
                            if (buscarPorEnfermedad(vs[0], 3).Count > 0)
                            {
                                return View(buscarPorEnfermedad(vs[0], 0));
                            }
                            else if (buscarPorResultado(vs[0], 3).Count > 0)
                            {
                                return View(buscarPorResultado(vs[0], 0));
                            }
                            else if (buscarPorConclucion(vs[0], 0).Count > 0)
                            {
                                return View(buscarPorConclucion(vs[0], 0));
                            }
                        }
                        return View(lista.OrderByDescending(a => a.Id_Formulario_S_O).ToList());
                    }
                    catch
                    {

                    }


                }
                else
                {
                   
                    List<Info_general> listInf  = db.Info_general.ToList();
                    List<Info_general> listInfGG = new List<Info_general>();
                    foreach (var inf in listInf.ToList())
                    {
                        if(inf.Nombre != null && inf.Apellido !=null && inf.Cedula != null && inf.Formulario_S_O != null)
                        {
                          if (inf.Nombre.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()) || inf.Apellido.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()) || inf.Cedula.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()) || inf.Formulario_S_O.Empresa.Nombre.Trim().ToUpper().Contains(vs[0].ToUpper()) || inf.Formulario_S_O.Estado.Trim().ToUpper().Contains(vs[0].Trim().ToUpper()))
                                                {
                                                    listInfGG.Add(inf);
                                                }
                        }
                      
                    }
                    List<Formulario_S_O> lista = new List<Formulario_S_O>();
                   
                    foreach (var info in listInfGG)
                    {
                        var fsoGet = db.Formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == info.Id_Formulario_S_O);
                        lista.Add(fsoGet);
                    }

                    if(lista.Count < 1)
                    {
                        if(buscarPorEnfermedad(vs[0],0).Count > 0)
                        { 
                        return View(buscarPorEnfermedad(vs[0],0));
                        }
                        else if(buscarPorResultado(vs[0], 0).Count > 0)
                        {
                            return View(buscarPorResultado(vs[0], 0));
                        }
                        else if(buscarPorConclucion(vs[0],0).Count > 0)
                        {
                            return View(buscarPorConclucion(vs[0], 0));
                        }
                    }
                    
                    return View(lista.OrderByDescending(a => a.Id_Formulario_S_O).ToList());
                }
            }


            return View();
        }
        List<Audiometria> audioMetrias;
        List<Examen_Visual> exVisual;
        
        private List<Formulario_S_O> buscarPorResultado(string resultado,int userRol)
        {
            List<Formulario_S_O> lista = new List<Formulario_S_O>();
           
            List<Audiometria> listAudio = new List<Audiometria>();
           
            List<Examen_Visual> listVisual = new List<Examen_Visual>();

           
            List<Espirometria> listEspiro = new List<Espirometria>();
            string[] rtype = resultado.Split(' ');
           
            switch(rtype[0])
            {
                case "A":
                    {
                        audioMetrias = db.Audiometrias.ToList();
                        string busqueda = rtype[1] + " " + rtype[2];
                        foreach (var audioM in audioMetrias)
                        {
                            if(audioM.Resultado == busqueda)
                            {
                                listAudio.Add(audioM);
                            }
                        }
                        foreach(var audio in listAudio)
                        {
                            var fsoGet = db.Formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == audio.Id_Formulario_S_O);
                            lista.Add(fsoGet);
                        }
                    }
                    break;
                case "V":
                    {
                        
                        exVisual = db.Examen_Visual.ToList();
                        string busqueda = rtype[1];
                        foreach (var exV in exVisual)
                        {
                            if (exV.Resultado == busqueda)
                            {
                                listVisual.Add(exV);
                            }
                        }
                        foreach (var visual in listVisual)
                        {
                            var fsoGet = db.Formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == visual.Id_Formulario_S_O);
                            lista.Add(fsoGet);
                        }
                    }
                    break;
                case "E":
                    {
                        List<int> idsEsp = db.Espirometrias.Select(a => a.Id_Espirometria).ToList();
                        List<string> resEsp = db.Espirometrias.Select(a => a.Resultado).ToList();
                        List<int?> fsoEsp = db.Espirometrias.Select(a => a.Id_Formulario_S_O).ToList();
                        int i = 0;
                        string busqueda = rtype[1] + " " + rtype[2];
                        foreach (var espiros in resEsp)
                        {
                            
                            if (espiros == busqueda)
                            {

                                listEspiro.Add(new Espirometria()
                                {
                                    Resultado = espiros,
                                    Id_Espirometria = idsEsp[i],
                                    Id_Formulario_S_O= fsoEsp[i] 
                                }
                                );
                            }
                            i++;
                        }
                        foreach (var espiro in listEspiro)
                        {
                            var fsoGet = db.Formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == espiro.Id_Formulario_S_O);
                            lista.Add(fsoGet);
                        }
                    }
                    break;
            }
            if (userRol == 3)
            {
                {
                    var user = Session["User"] as Usuario;
                    var idempresa = db.Empresas.FirstOrDefault(a => a.Id_Usuario == user.Id_usuario).Id_Empresa;

                    var formulario_S_O = lista.Where(a => a.Id_Empresa == idempresa && a.Estado == "Visible");

                    return formulario_S_O.OrderByDescending(a => a.Id_Formulario_S_O).ToList();

                }
            }

            return lista.OrderByDescending(a => a.Id_Formulario_S_O).ToList();
        }
        private List<Formulario_S_O> buscarPorEnfermedad(string enfermedad, int userRol)
        {
            
            var histClinicas = db.Historia_Clinica.ToList();
            List<Historia_Clinica> listHist = new List<Historia_Clinica>();
            List<Formulario_S_O> lista = new List<Formulario_S_O>();
           
            foreach(var histo in histClinicas) { 
            var metahistCli = histo.GetType().GetProperties();
                foreach(var name in metahistCli)
                {
                    if(name.Name.ToUpper().Contains(enfermedad.ToUpper()))
                    {
                            var val = name.GetValue(histo);
                            if (val is bool)
                            {
                                if(Convert.ToBoolean(val) == true)
                                {
                                    listHist.Add(histo);
                                    break;
                                }
                            }
                    }
                }

            }

           

                foreach (var info in listHist)
            {
                var fsoGet = db.Formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == info.Id_Formulario_S_O);
                lista.Add(fsoGet);
            }
            if (userRol == 3)
            {
                {
                    var user = Session["User"] as Usuario;
                    var idempresa = db.Empresas.FirstOrDefault(a => a.Id_Usuario == user.Id_usuario).Id_Empresa;

                    var formulario_S_O = lista.Where(a => a.Id_Empresa == idempresa && a.Estado == "Visible");

                    return formulario_S_O.OrderByDescending(a => a.Id_Formulario_S_O).ToList();

                }
            }
            
                return lista.OrderByDescending(a => a.Id_Formulario_S_O).ToList();
            

        }
        private List<Formulario_S_O> buscarPorConclucion(string conclucion, int userRol)
        {
            var csoList = db.CSOes.ToList();
            List<CSO> csoEncontrados = new List<CSO>();
            switch (conclucion)
            {
                case "APTO":
                    {
                        foreach(var cso in csoList)
                        {
                            if(cso.Apto == true)
                            {
                                csoEncontrados.Add(cso);
                            }
                        }
                    }
                    break;
                case "APTO CON RESTRICIÓN":
                    {
                        foreach (var cso in csoList)
                        {
                            if (cso.Apto_con_restriccion == true)
                            {
                                csoEncontrados.Add(cso);
                            }
                        }
                    }
                    break;
                case "NO APTO":
                    {
                        foreach (var cso in csoList)
                        {
                            if (cso.No_Apto == true)
                            {
                                csoEncontrados.Add(cso);
                            }
                        }
                    }
                    break;
                case "APLAZADO":
                    {
                        foreach (var cso in csoList)
                        {
                            if (cso.Aplazado == true)
                            {
                                csoEncontrados.Add(cso);
                            }
                        }

                    }
                    break;
            }
            List<Formulario_S_O> fsos = new List<Formulario_S_O>();
            foreach(var cso in csoEncontrados)
            {
                var fso = db.Formulario_S_O.Find(cso.Id_Formulario_S_O);
                fsos.Add(fso);
            }

            return fsos;
        }

            // GET: Formulario_S_O/Details/5
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
            Formulario_S_O formulario_S_O = db.Formulario_S_O.Find(id);
            if (formulario_S_O == null)
            {
                return HttpNotFound();
            }
            return View(formulario_S_O);
        }
        // Post: Formulario_S_O/Details/5
        [HttpPost,ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult SubirArchivos(FormCollection collection)
        {
            ArchivosExtra archivo = new ArchivosExtra();
            archivo.Id_Formulario_S_O = Convert.ToInt32(collection["data1"]);
            archivo.Descripcion = collection["data"].ToString();
                
                if(Request.Files.Count > 0) 
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
                    
                    var path = Path.Combine(Server.MapPath("~/Images/"), nombreArchivo.Insert(1,codigo));

                    archivo.link = "../../Images/" + nombreArchivo.Insert(1, codigo);
                    file.SaveAs(path);

                db.ArchivosExtras.Add(archivo);
                db.SaveChanges();
                }
            Formulario_S_O formulario_S_O = db.Formulario_S_O.Find(archivo.Id_Formulario_S_O);
            if (formulario_S_O == null)
            {
                return HttpNotFound();
            }
            return View(formulario_S_O);
            
        }
        //GET: Formulario_S_O/FormulariosAVencer 
        public ActionResult FormulariosAVencer()
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            var fechavence = DateTime.Now.AddMonths(-10);
            List<Formulario_S_O> formularios = new List<Formulario_S_O>();
            List<Formulario_S_O> formulariosEmpresa = new List<Formulario_S_O>();
            List<Info_general> infgereal = new List<Info_general>();
            var empresa = db.Empresas.FirstOrDefault(a => a.Id_Usuario == user.Id_usuario);

            if (user.id_rol == 3)
            {

                infgereal = db.Info_general.Where(a => a.Fecha <= fechavence && a.Formulario_S_O.Empresa.Id_Usuario == user.Id_usuario).ToList();

            }
            else
            {
                infgereal = db.Info_general.Where(a => a.Fecha <= fechavence).ToList();
            }
            foreach (var inf in infgereal)
            {
                formularios.Add(db.Formulario_S_O.Find(inf.Id_Formulario_S_O));
            }
            if (user.id_rol == 3)
            {

                formulariosEmpresa = formularios.Where(a => a.Estado == "Visible").ToList();

                return View(formulariosEmpresa.OrderByDescending(a => a.Id_Formulario_S_O).ToList());
                
            }

                return View(formularios.OrderByDescending(a => a.Id_Formulario_S_O).ToList());
        }
        //POST:Formulario_S_O/FormulariosAVencer 
        [HttpPost, ActionName("FormulariosAVencer")]
        [ValidateAntiForgeryToken]
        public ActionResult FormulariosAVencer(FormCollection collection)
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            } 

            var fechavence = DateTime.Now.AddMonths(-10);
            List<Formulario_S_O> formularios = new List<Formulario_S_O>();
            List<Info_general> infgereal = new List<Info_general>() ;
            
            if (user.Id_usuario == 3)
            { DateTime fechaini;

               DateTime.TryParse(collection["fecha"].ToString(), out fechaini);

             infgereal = db.Info_general.Where(a => a.Fecha <= fechavence && a.Formulario_S_O.Empresa.Id_Usuario == user.Id_usuario && a.Fecha >= fechaini).ToList();
            }
            else
            {
                DateTime fechaini;

                DateTime.TryParse(collection["fecha"].ToString(), out fechaini);
                if(fechaini < DateTime.Now.AddYears(-2000))
                {

                    string emp = collection["data"].ToString();
                    if (emp != "")
                    {
                        infgereal = db.Info_general.Where(a => a.Fecha <= fechavence).ToList();
                        foreach (var inf in infgereal)
                        {
                            List<Formulario_S_O> forms = db.Formulario_S_O.Where(a => a.Id_Formulario_S_O == inf.Id_Formulario_S_O && a.Empresa.Nombre.Contains(emp)).ToList();
                            foreach (var frm in forms)
                            {
                                formularios.Add(frm);
                            }

                        }
                    }
                  
                      
                    

                }
                else 
                {
                    infgereal = db.Info_general.Where(a => a.Fecha <= fechavence && a.Fecha >= fechaini).ToList();
                    foreach (var inf in infgereal)
                    {
                        formularios.Add(db.Formulario_S_O.Find(inf.Id_Formulario_S_O));
                    }
                } 
            }
                
           
          
            
            return View(formularios.OrderByDescending(a => a.Id_Formulario_S_O).ToList());
        }

        // GET: Formulario_S_O/Create
        public ActionResult Create()
        {
            var user = Session["User"] as Usuario;
            if(user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }

            ViewBag.Id_Empresa = new SelectList(db.Empresas, "Id_Empresa", "Nombre");
            return View();
        }

        // POST: Formulario_S_O/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Formulario_S_O,Id_Empresa")] Formulario_S_O formulario_S_O)
        {
            if (ModelState.IsValid)
            {
                formulario_S_O.Estado = "Incompleto";
                db.Formulario_S_O.Add(formulario_S_O);
                db.SaveChanges();
                Session["FormSO"] = formulario_S_O;
                return RedirectToAction("Create","Info_general");
            }

            ViewBag.Id_Empresa = new SelectList(db.Empresas, "Id_Empresa", "Nombre", formulario_S_O.Id_Empresa);
            return View(formulario_S_O);
        }

        // GET: Formulario_S_O/Edit/5
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
            Formulario_S_O formulario_S_O = db.Formulario_S_O.Find(id);
            if (formulario_S_O == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresas, "Id_Empresa", "Nombre", formulario_S_O.Id_Empresa);
           
            return View(formulario_S_O);
        }

        // POST: Formulario_S_O/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Formulario_S_O,Id_Usuario,Id_Empresa,Estado")] Formulario_S_O formulario_S_O)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulario_S_O).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empresa = new SelectList(db.Empresas, "Id_Empresa", "Nombre", formulario_S_O.Id_Empresa);
            return View(formulario_S_O);
        }

        // GET: Formulario_S_O/Delete/5
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
            Formulario_S_O formulario_S_O = db.Formulario_S_O.Find(id);
            if (formulario_S_O == null)
            {
                return HttpNotFound();
            }
            return View(formulario_S_O);
        }

        // POST: Formulario_S_O/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as Usuario;
            if (user == null)
            {
                return RedirectToAction("Create", "Usuarios");
            }
            Formulario_S_O formulario_S_O = db.Formulario_S_O.Find(id);
            db.Formulario_S_O.Remove(formulario_S_O);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PrintPreview(int? id)
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
            Formulario_S_O formulario_S_O = db.Formulario_S_O.Find(id);
            if (formulario_S_O == null)
            {
                return HttpNotFound();
            }
            return new ViewAsPdf(formulario_S_O);
           // return View(formulario_S_O);
        }
        [HttpGet]
        public ActionResult SendEmail(int? idSo)
        {

            Formulario_S_O formu = this.db.Formulario_S_O.FirstOrDefault(x => x.Id_Formulario_S_O == idSo);

            Info_general _general = this.db.Info_general.FirstOrDefault(x => x.Id_Formulario_S_O == idSo);

            Empresa empresa = this.db.Empresas.FirstOrDefault( x => x.Id_Empresa == formu.Id_Empresa);
            try
            {
                MailAddress from = new MailAddress("teddramos@cisam.com.do", "cisam");
                MailAddress to = new MailAddress(empresa.Email, empresa.Nombre);
                string password = "K2z7#a9s4";
                string str2 = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/teplateforemail.html")))
                {
                    str2 = reader.ReadToEnd();
                }
                str2 = str2.Replace("{cliente}", empresa.Nombre).Replace("{empleado}", _general.Nombre + " " + _general.Apellido);
                string str3 = "Expediente Listo";
                SmtpClient client1 = new SmtpClient();
                client1.Host = "mail.negox.com";
                client1.Port = 0x24b;
                client1.EnableSsl = true;
                client1.DeliveryMethod = SmtpDeliveryMethod.Network;
                client1.UseDefaultCredentials = false;
                client1.Credentials = new NetworkCredential(from.Address, password);
                SmtpClient client = client1;
                MailMessage message1 = new MailMessage(from, to);
                message1.Subject = str3;
                message1.Body = str2;
                message1.IsBodyHtml = true;
                using (MailMessage message = message1)
                {
                    client.Send(message);
                }
                ViewBag.mensaje = "true";
                Session.Add("mensaje", "true");
                return base.RedirectToAction("Edit/" + idSo);
            }
            catch (Exception exception)
            {
                // ViewBag.mensaje = "Ocurrio un error enviando el email:" + exception.Message;
                Session.Add("mensaje", "Ocurrio un error enviando el email:" + exception.Message);
            }
            return base.RedirectToAction("Edit/" + idSo);
        }
        public JsonResult listaUsuarios(int userSend)
        {
            var usuario = db.Usuarios.Find(userSend);
            var usuarios = new List<UsersForMessages>();
            if(usuario.id_rol == 1)
            {
                usuarios = db.Usuarios.Select(x => new UsersForMessages { id = x.Id_usuario, name = x.Nombre_completo??x.Email,rol =(int)x.id_rol }).Where(x=>x.rol != 5).ToList();
            }
            if(usuario.id_rol == 3)
            {
                usuarios = db.Usuarios.Select(x => new UsersForMessages { id = x.Id_usuario, name = x.Nombre_completo ?? x.Email, rol = (int)x.id_rol }).Where(x => x.rol == 1).ToList();
            }
            if (usuario.id_rol == 2 || usuario.id_rol == 4)
            {
                usuarios = db.Usuarios.Select(x => new UsersForMessages { id = x.Id_usuario, name = x.Nombre_completo ?? x.Email, rol = (int)x.id_rol }).Where(x => x.rol != 3 && x.rol != 5).ToList();
            }
            return Json(usuarios,JsonRequestBehavior.AllowGet);
        } 
        public JsonResult Notificaciones()
        {
            var user = Session["User"] as Usuario;

            var notificaciones = new List<Notificacion>();
           
            int NotificationCount = 0;
            var audiometrias = db.Audiometrias.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
            NotificationCount += audiometrias.Count();
            try
            {
                foreach (var audio in audiometrias)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)audio.Id_Formulario_S_O;
                    noti.Expediente = "Audiometrias";
                    noti.Mensaje = "Completar la Audiometria del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + audio.Id_AudioMetria;
                    noti.fechaYhora = audio.Ultima_modificacion != null?audio.Ultima_modificacion.Value.ToShortDateString():DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);

                }
                var concentimiento = db.Consentimiento_Informado.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += concentimiento.Count();
                foreach (var data in concentimiento)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "Consentimiento_Informado";
                    noti.Mensaje = "Completar el Concentimiento informado del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Consentimiento_Informado;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var Csoes = db.CSOes.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += Csoes.Count();
                foreach (var data in Csoes)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_CSO;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var ekgs = db.EKGs.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += ekgs.Count();
                foreach (var data in ekgs)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_EKG;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var espirometrias = db.Espirometrias.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += espirometrias.Count();
                foreach (var data in espirometrias)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Espirometria;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var visuales = db.Examen_Visual.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += visuales.Count();
                foreach (var data in visuales)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Examen_Visual;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var hemogramas = db.Hemogramas.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += hemogramas.Count();
                foreach (var data in hemogramas)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Hemograma;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var historias = db.Historia_Clinica.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += historias.Count();
                foreach (var data in historias)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Historia_Clinica;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var laboratorios = db.Laboratorios.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += laboratorios.Count();
                foreach (var data in laboratorios)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Laboratorio;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var maneros = db.Mareos.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += maneros.Count();
                foreach (var data in maneros)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Mareo;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var preEspiros = db.Pre_espirometria.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += preEspiros.Count();
                foreach (var data in preEspiros)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_Pre_espirometria;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
                var rayos = db.RayosXes.Where(x => x.Usuario_que_modifico == user.Id_usuario && x.Estado != "Finalizada");
                NotificationCount += rayos.Count();
                foreach (var data in rayos)
                {
                    var noti = new Notificacion();
                    noti.tipo = "Notificacion";
                    noti.NumeroExpediente = (long)data.Id_Formulario_S_O;
                    noti.Expediente = "CSOes";
                    noti.Mensaje = "Completar el Certificado de salud ocupacional del expediente: " + noti.NumeroExpediente;
                    noti.Link = "/" + noti.Expediente + "/Edit/" + data.Id_rayos_X;
                    noti.fechaYhora = data.Ultima_modificacion != null ? data.Ultima_modificacion.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                    notificaciones.Add(noti);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(notificaciones,JsonRequestBehavior.AllowGet);

        }
        [HttpPost]       
        public JsonResult SendMessage(SimpleMessage mensaje)
        {
            
            db.Mensajes.Add(new Mensaje
            {
                Id_usuario = mensaje.userSender,
                Id_usuario_recive = mensaje.userReceiver,
                Mensaje1=mensaje.message,
                FechaYhora = DateTime.Now,
                Estado = "ENVIADO"
            }) ;
            db.SaveChanges();
            return Json(mensaje);
        }
        public JsonResult getMessages(int userSend, int userRecibe)
        {
            var msj = db.Mensajes.Where(x => (x.Id_usuario == userSend || x.Id_usuario == userRecibe) && (x.Id_usuario_recive == userSend || x.Id_usuario_recive == userRecibe));
           var mensajes = new List<SimpleMessage>(); 
            foreach (var m in msj)
            {
                if(userSend == m.Id_usuario_recive)
                {
                    m.Estado = "VISTO";
                }
                mensajes.Add(new SimpleMessage
                {
                    userReceiver = m.Id_usuario_recive.Value,
                    userSender = m.Id_usuario.Value,
                    fechaYhora = m.FechaYhora.Value.ToShortDateString() + " "+m.FechaYhora.Value.ToShortTimeString(),
                    message = m.Mensaje1
                }) ;
            }
            db.SaveChanges ();
            
            return Json(mensajes,JsonRequestBehavior.AllowGet);
        }
        public JsonResult updateMessages(int userSend, int userRecibe)
        {
            var msj = db.Mensajes.Where(x => (x.Id_usuario == userSend || x.Id_usuario == userRecibe) && (x.Id_usuario_recive == userSend || x.Id_usuario_recive == userRecibe));
            var mensajes = new List<SimpleMessage>();
            foreach (var m in msj)
            {
                if (m.Id_usuario_recive != userSend)
                {
                    m.Estado = "VISTO";
                }
                mensajes.Add(new SimpleMessage
                {
                    userReceiver = m.Id_usuario_recive.Value,
                    userSender = m.Id_usuario.Value,
                    fechaYhora = m.FechaYhora.Value.ToShortDateString() + " " + m.FechaYhora.Value.ToShortTimeString(),
                    message = m.Mensaje1
                });
            }
            db.SaveChanges();

            return Json(mensajes, JsonRequestBehavior.AllowGet);
        }
        public JsonResult NewMessageConversation(int userSend, int userRecibe)
        {
            var msj = db.Mensajes.Where(x => ( x.Id_usuario == userRecibe) && (x.Id_usuario_recive == userSend) && x.Estado == "ENVIADO");
            if(msj.Count() > 0)
            {
                return Json(new { mensajes =  msj.Count()},JsonRequestBehavior.AllowGet);
            }
            return Json(new {mensajes = 0},JsonRequestBehavior.AllowGet);
        }
        public JsonResult MessagesNotifications(int userSend)
        {
            var msj = db.Mensajes.Where(x => x.Id_usuario_recive == userSend && x.Estado == "ENVIADO");
            var notify = new List<Object>();
            if(msj.Count() > 0)
            {
                foreach(var m in msj)
                {
                    var user = db.Usuarios.Find(m.Id_usuario);
                    notify.Add(new { userSend = m.Id_usuario_recive, userRecibe = m.Id_usuario, message = m.Mensaje1, nombre =user.Nombre_completo,
                    fechaYhora= m.FechaYhora.Value.ToShortDateString() + " " + m.FechaYhora.Value.ToShortTimeString()});
                }
                return Json(notify, JsonRequestBehavior.AllowGet);
            }
            return Json(notify,JsonRequestBehavior.AllowGet);

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
