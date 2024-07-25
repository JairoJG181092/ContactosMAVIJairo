using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactosMavi.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public string TipoContacto { get; set; }
        [Required(ErrorMessage ="Telefono Fijo Obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El teléfono fijo debe tener exactamente 10 dígitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]
        public string TelefonoFijo { get; set; }
        [Required(ErrorMessage = "Telefono Movil Obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El teléfono movil debe tener exactamente 10 dígitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]
        public string TelefonoMovil { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string EstadoCivil { get; set; }
    }
}