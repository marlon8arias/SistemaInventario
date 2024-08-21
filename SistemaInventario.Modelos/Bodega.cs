using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    // Por default la clase se crea como internal, pero la cambiamos a public.
    public class Bodega 
    {
        // Utilizando data-notations
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(60, ErrorMessage = "El nombre debe contener máximo 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(100, ErrorMessage = "la descripcón debe contener máximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [MaxLength(1, ErrorMessage = "El estado solo puede contener 1 caracter")]
        public bool Estado { get; set; }
    }
}
