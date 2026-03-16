using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebParaMelvin.Models
{
    public class IndexFSOData
    {
        public int Id_Formulario_S_O { get; set; }
        public string Empresa { get; set; }
        public string Tipo_de_evaluacion { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }
        public string Pais_de_nacimiento { get; set; }
        public int Id_Empresa { get; set; }
        public int? Id_Usuario { get; set; } 
    }
}