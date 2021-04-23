using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace segundoBlazor.Shared.Libro
{
    public class LibroDTO
    {

        public int idLibro { get; set; }

        [Required(ErrorMessage = "Ingrese un Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Ingrese un Resumen")]
        public string Resumen { get; set; }
        [Required(ErrorMessage = "Ingrese el numero de paginas")]
        public int? numPaginas { get; set; }
        [Required(ErrorMessage = "Ingrese el stock")]
        public int? Stock { get; set; }
        public string libroPDF { get; set; }
        public string caratula { get; set; }
        [Required(ErrorMessage = "Ingrese un Autor")]
        public string Iidautor { get; set; }
    }
}
