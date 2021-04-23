using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace segundoBlazor.Shared
{
    public class TipoLibroCLS
    {

        
        public int Iidtipolibro { get; set; }

        [Required(ErrorMessage = "Debe Ingresar el nombre del tipo libro")]
        public string Nombretipolibro { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la descripción")]
        public string Descripcion { get; set; }
    }
}
