using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace segundoBlazor.Shared.Persona
{
    public class PersonaEditarCLS
    {
        public int idPersona { get; set; }

        [Required(ErrorMessage ="Ingrese el Nombre de la persona")]
        [MaxLength(100, ErrorMessage = "La longitud debe ser de 100")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el Primer Apellido")]
        [MaxLength(150, ErrorMessage = "La longitud debe ser de 150")]
        public string aPaterno { get; set; }
        [Required(ErrorMessage = "Ingrese el segundo Apellido")]
        [MaxLength(150, ErrorMessage = "La longitud debe ser de 150")]
        public string aMaterno { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud debe ser de 50")]
        public string telefono { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud debe ser de 100")]
        public string correo { get; set; }


        public DateTime fechaNac { get; set; } = DateTime.Now;

    }
}
