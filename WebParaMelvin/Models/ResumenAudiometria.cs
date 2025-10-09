using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebParaMelvin.Models
{
    public class ResumenAudiometria
    {
        
            public Nullable<System.DateTime> Fecha { get; set; }
            public Nullable<int> Id_Empleado { get; set; }
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Sexo { get; set; }
            public Nullable<System.DateTime> Fecha_de_nacimiento { get; set; }
            public string Edad { get; set; }
            public string Empresa { get; set; }
            public string Departamento { get; set; }
            public string Puesto { get; set; }
            public string Otoscopia_Izquierda { get; set; }
            public string Otoscopia_Derecha { get; set; }
            public Nullable<int> Oiz_500 { get; set; }
            public Nullable<int> Oiz_1K { get; set; }
            public Nullable<int> Oiz_2K { get; set; }
            public Nullable<int> Oiz_3K { get; set; }
            public Nullable<int> Oiz_4K { get; set; }
            public Nullable<int> Oiz_6K { get; set; }
            public Nullable<int> Oiz_8K { get; set; }
            public Nullable<int> Ode_500 { get; set; }
            public Nullable<int> Ode_1K { get; set; }
            public Nullable<int> Ode_2K { get; set; }
            public Nullable<int> Ode_3K { get; set; }
            public Nullable<int> Ode_4K { get; set; }
            public Nullable<int> Ode_6K { get; set; }
            public Nullable<int> Ode_8K { get; set; }
        
    }
}