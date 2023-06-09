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
    
    public partial class Audiometria
    {
        public int Id_AudioMetria { get; set; }
        public bool trabaja_trabajado_en_areas_ruidosas { get; set; }
        public bool tipo_de_proteccion_auditiva { get; set; }
        public bool Ha_tenido_infecciones_en_los_oidos { get; set; }
        public bool Ha_tenido_zumbido_en_los_oidos { get; set; }
        public Nullable<bool> Ha_estado_en_la_milicia_o_el_ejercito_no { get; set; }
        public Nullable<bool> trabaja_trabajado_en_areas_ruidosas_no { get; set; }
        public Nullable<bool> tipo_de_proteccion_auditiva_no { get; set; }
        public Nullable<bool> Ha_tenido_infecciones_en_los_oidos_no { get; set; }
        public Nullable<bool> Ha_tenido_zumbido_en_los_oidos_no { get; set; }
        public bool Ha_estado_en_la_milicia_o_el_ejercito { get; set; }
        public string Escucha_musica_alta_o_usa_audifonos { get; set; }
        public string Horas_desde_la_ultima_exposicion { get; set; }
        public string Exposicion { get; set; }
        public string Entrenamiento_recibido { get; set; }
        public string Autoevaluacion_de_su_audicion_ { get; set; }
        public string Otoscopia_Izquierda { get; set; }
        public string Otoscopia_Derecha { get; set; }
        public string Comentarios { get; set; }
        public Nullable<int> Oiz_500 { get; set; }
        public Nullable<int> Oiz_1K { get; set; }
        public Nullable<int> Oiz_2K { get; set; }
        public Nullable<int> Oiz_3K { get; set; }
        public Nullable<int> Oiz_4K { get; set; }
        public Nullable<int> Oiz_6K { get; set; }
        public Nullable<int> Oiz_8K { get; set; }
        public Nullable<int> Oiz_5002 { get; set; }
        public Nullable<int> Oiz_1K2 { get; set; }
        public Nullable<int> Oiz_2K2 { get; set; }
        public Nullable<int> Oiz_3K2 { get; set; }
        public Nullable<int> Oiz_4K2 { get; set; }
        public Nullable<int> Oiz_6K2 { get; set; }
        public Nullable<int> Oiz_8K2 { get; set; }
        public Nullable<int> Ode_500 { get; set; }
        public Nullable<int> Ode_1K { get; set; }
        public Nullable<int> Ode_2K { get; set; }
        public Nullable<int> Ode_3K { get; set; }
        public Nullable<int> Ode_4K { get; set; }
        public Nullable<int> Ode_6K { get; set; }
        public Nullable<int> Ode_8K { get; set; }
        public Nullable<int> Ode_5002 { get; set; }
        public Nullable<int> Ode_1K2 { get; set; }
        public Nullable<int> Ode_2K2 { get; set; }
        public Nullable<int> Ode_3K2 { get; set; }
        public Nullable<int> Ode_4K2 { get; set; }
        public Nullable<int> Ode_6K2 { get; set; }
        public Nullable<int> Ode_8K2 { get; set; }
        public Nullable<int> Id_Formulario_S_O { get; set; }
        public byte[] Firma { get; set; }
        public string Resultado { get; set; }
        public Nullable<bool> Modificado { get; set; }
        public Nullable<System.DateTime> Ultima_modificacion { get; set; }
        public Nullable<int> Usuario_que_modifico { get; set; }
    
        public virtual Formulario_S_O Formulario_S_O { get; set; }
    }
}
