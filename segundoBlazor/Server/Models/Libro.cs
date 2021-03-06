using System;
using System.Collections.Generic;

#nullable disable

namespace segundoBlazor.Server.Models
{
    public partial class Libro
    {
        public Libro()
        {
            DetalleReservas = new HashSet<DetalleReserva>();
        }

        public int Iidlibro { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public int? Numpaginas { get; set; }
        public int? Stock { get; set; }
        public string Libropdf { get; set; }
        public string Fotocaratula { get; set; }
        public int? Bhabilitado { get; set; }
        public int? Iidautor { get; set; }

        public virtual Autor IidautorNavigation { get; set; }
        public virtual ICollection<DetalleReserva> DetalleReservas { get; set; }
    }
}
