//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebParaMelvin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Info_general
    {
        public int Id_Info_General { get; set; }
        public string Empresa { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Departamento { get; set; }
        public string Posicion { get; set; }
        public string Tipo_de_evaluacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public Nullable<System.DateTime> Fecha_de_nacimiento { get; set; }
        public string Edad { get; set; }
        public Nullable<int> Id_Empleado { get; set; }
        public Nullable<int> Id_Formulario_S_O { get; set; }
        public Nullable<System.DateTime> Ultima_modificacion { get; set; }
        public Nullable<int> Usuario_que_modifico { get; set; }
        public bool Pre_espirometria { get; set; }
        public bool Espirometria { get; set; }
        public bool Audiometria { get; set; }
        public bool Capacidad_fisica { get; set; }
        public bool Laboratorio { get; set; }
        public bool Radiografia { get; set; }
        public bool Hemografia { get; set; }
        public bool EKG { get; set; }
        public bool Examen_visual { get; set; }
        public bool Bateria_de_un_mes { get; set; }
        public bool Bateria_Completa { get; set; }
        public bool Historia_clinica_y_examen_fisico { get; set; }
        public bool Consentimiento_informado { get; set; }
    
        public virtual Formulario_S_O Formulario_S_O { get; set; }
    }
}
