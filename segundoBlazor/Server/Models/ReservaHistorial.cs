using System;
using System.Collections.Generic;

#nullable disable

namespace segundoBlazor.Server.Models
{
    public partial class ReservaHistorial
    {
        public int Iidhistorial { get; set; }
        public int? Iidreserva { get; set; }
        public int? Iidestado { get; set; }
        public string Vobservacion { get; set; }
        public int? Iidusuario { get; set; }
        public int? Bhabilitado { get; set; }

        public virtual ReservaEstado IidestadoNavigation { get; set; }
        public virtual Reserva IidreservaNavigation { get; set; }
        public virtual Usuario IidusuarioNavigation { get; set; }
    }
}
