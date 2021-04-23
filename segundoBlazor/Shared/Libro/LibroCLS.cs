using System;
using System.Collections.Generic;
using System.Text;

namespace segundoBlazor.Shared.Libro
{
    public class LibroCLS
    {
        public int idLibro { get; set; }
        public string Titulo { get; set; }
        public string nombreAutor { get; set; }
        public int? numPaginas { get; set; }
        public int? Stock { get; set; }
    }
}
