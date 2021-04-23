using System;
using System.Collections.Generic;
using System.Text;

namespace segundoBlazor.Shared
{
    public class TareaCLS
    {
        public string diaSemana { get; set; }
        public string tarea { get; set; }
        public bool realizado { get; set; }

        public DateTime fechaTarea { get; set; }
    }
}
