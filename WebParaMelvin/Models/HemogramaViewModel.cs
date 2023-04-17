using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParaMelvin.Models
{
    public partial class Hemograma
    {
       public HttpPostedFileBase Data { get; set; }
    }
    public partial class Espirometria
    {
      
        public HttpPostedFileBase Firma { get; set; }
    }
    public partial class  RayosX
    {
        
        public HttpPostedFileBase Archivo { get; set; }
        public HttpPostedFileBase Archivo2 { get; set; }

    }
    public partial class Consentimiento_Informado
    {
       
        public HttpPostedFileBase DataFirma { get; set; }
        public HttpPostedFileBase DataHuella { get; set; }
    }
    public partial class EKG
    {
       
        public HttpPostedFileBase Data { get; set; }
    }
    public partial class Historia_Clinica
    {
        public HttpPostedFileBase Archivo { get; set; }
    }
    public partial class CSO
    {
        public HttpPostedFileBase Archivo { get; set; }
    }
    public partial class Audiometria
    {
        public HttpPostedFileBase Archivo { get; set; }
    }
    public partial class Examen_Visual
    {
        public HttpPostedFileBase Archivo { get; set; }
    }
    public partial class Mareo
    {
        public HttpPostedFileBase Archivo { get; set; }
    }
    public partial class Laboratorio
    {
        public HttpPostedFileBase Archivo { get; set; }
        public HttpPostedFileBase Archivo1 { get; set; }
    }
    public partial class ArchivosExtra
    {
        public HttpPostedFileBase Archivo { get; set; }
    }
    public class FormSearchData
    {
        public string tipo { get; set; }
        public string data { get; set; }
    }
    public class Notificacion
    {
        public string tipo { get; set; }
        public long NumeroExpediente { get; set; }  
        public string Expediente { get; set; }  
        public string NombreUsuario { get; set; }
        public string Mensaje { get; set; }
        public string Link { get; set; }
        public DateTime fechaYhora { get; set; }
    }
}