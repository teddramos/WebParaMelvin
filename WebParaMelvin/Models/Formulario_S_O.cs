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
    
    public partial class Formulario_S_O
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formulario_S_O()
        {
            this.CSOes = new HashSet<CSO>();
            this.ArchivosExtras = new HashSet<ArchivosExtra>();
            this.Audiometrias = new HashSet<Audiometria>();
            this.Consentimiento_Informado = new HashSet<Consentimiento_Informado>();
            this.EKGs = new HashSet<EKG>();
            this.Espirometrias = new HashSet<Espirometria>();
            this.Examen_Visual = new HashSet<Examen_Visual>();
            this.Hemogramas = new HashSet<Hemograma>();
            this.Historia_Clinica = new HashSet<Historia_Clinica>();
            this.Laboratorios = new HashSet<Laboratorio>();
            this.Mareos = new HashSet<Mareo>();
            this.Pre_espirometria = new HashSet<Pre_espirometria>();
            this.RayosXes = new HashSet<RayosX>();
            this.Info_general = new HashSet<Info_general>();
        }
    
        public int Id_Formulario_S_O { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> Ultima_modificacion { get; set; }
        public Nullable<int> Usuario_que_modifico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CSO> CSOes { get; set; }
        public virtual Empresa Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArchivosExtra> ArchivosExtras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Audiometria> Audiometrias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consentimiento_Informado> Consentimiento_Informado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EKG> EKGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Espirometria> Espirometrias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Examen_Visual> Examen_Visual { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hemograma> Hemogramas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia_Clinica> Historia_Clinica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laboratorio> Laboratorios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mareo> Mareos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pre_espirometria> Pre_espirometria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RayosX> RayosXes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Info_general> Info_general { get; set; }
    }
}
