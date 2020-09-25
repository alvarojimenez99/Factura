//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Factura.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class empresas
    {
        public int id { get; set; }
        

        [Required(ErrorMessage = "Nombre Requerido")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "RUC Requerido")]
        public string ruc { get; set; }
        public string website { get; set; }
        
        [Required(ErrorMessage = "Contacto Requerido")]
        public string contact { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefono Requerido")]
        public string phone { get; set; }
        public System.DateTime created_at { get; set; }
        public int active { get; set; }
        
        public string direccion { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public string address { get; set; }
    }
}