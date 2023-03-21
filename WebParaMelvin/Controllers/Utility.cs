using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebParaMelvin.Models;

namespace WebParaMelvin.Controllers
{
    public class Utility
    {
        private ceisamco_form_s_oEntities db = new ceisamco_form_s_oEntities();
        public Models.Usuario login(Models.Usuario usuario)
        {

            var user = db.Usuarios.FirstOrDefault(e =>e.Email == usuario.Email);
            if(user != null)
            {
                if (user.Password == usuario.Password)
                { return user; }

            }
            throw new Exception("El Usuario o la contraseña estan equivocados \n O tu cuenta ha sido bloqueada");
        }
        public Models.Formulario_S_O GetFormulario_S_O(int id)
        {
            return db.Formulario_S_O.FirstOrDefault(a => a.Id_Formulario_S_O == id);
        }
    }
}