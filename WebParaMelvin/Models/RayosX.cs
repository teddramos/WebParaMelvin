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
    
    public partial class RayosX
    {
        public int Id_rayos_X { get; set; }
        public string tecnica { get; set; }
        public string Hallasgos { get; set; }
        public string Impresion_diagnostica { get; set; }
        public string tecnica2 { get; set; }
        public string Hallasgos2 { get; set; }
        public string Impresion_diagnostica2 { get; set; }
        public Nullable<int> Id_Formulario_S_O { get; set; }
        public byte[] Firma { get; set; }
        public byte[] Firma2 { get; set; }
        public Nullable<bool> Modificado { get; set; }
        public Nullable<System.DateTime> Ultima_modificacion { get; set; }
        public Nullable<int> Usuario_que_modifico { get; set; }
        public string Estado { get; set; }
    
        public virtual Formulario_S_O Formulario_S_O { get; set; }
    }
}
