using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SeguimientoApi.Models
{
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdRol { get; set; }
        public Guid IdPersona { get; set; }
        public bool Estado { get; set; }
    }
}
