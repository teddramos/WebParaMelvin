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
    
    public partial class Usuario_Rol
    {
        public int Id_usuario_rol { get; set; }
        public Nullable<int> Id_Rol { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
    
        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
