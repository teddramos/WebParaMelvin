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
    
    public partial class Pre_espirometria
    {
        public int Id_Pre_espirometria { get; set; }
        public bool pulmon_torax_abdomen { get; set; }
        public bool infarto_al_corazon { get; set; }
        public bool retina_cirugia { get; set; }
        public bool problema_corazon { get; set; }
        public bool medicamento_tuberculosis { get; set; }
        public string Esta_embarazada { get; set; }
        public bool Presion_arterial { get; set; }
        public bool infeccion_respirtatoria { get; set; }
        public bool medicamento_respiracion { get; set; }
        public bool cigarro_puro_pipa { get; set; }
        public bool ejercicio_fuerte { get; set; }
        public bool comida_completa { get; set; }
        public string Comentarios { get; set; }
        public Nullable<int> Id_Formulario_S_O { get; set; }
        public bool pulmon_torax_abdomenA { get; set; }
        public bool infarto_al_corazonA { get; set; }
        public bool retina_cirugiaA { get; set; }
        public bool problema_corazonA { get; set; }
        public bool medicamento_tuberculosisA { get; set; }
        public bool Presion_arterialA { get; set; }
        public bool infeccion_respirtatoriaA { get; set; }
        public bool medicamento_respiracionA { get; set; }
        public bool cigarro_puro_pipaA { get; set; }
        public bool ejercicio_fuerteA { get; set; }
        public bool comida_completaA { get; set; }
        public Nullable<bool> Modificado { get; set; }
        public Nullable<System.DateTime> Ultima_modificacion { get; set; }
        public Nullable<int> Usuario_que_modifico { get; set; }
        public string Estado { get; set; }
    
        public virtual Formulario_S_O Formulario_S_O { get; set; }
    }
}
