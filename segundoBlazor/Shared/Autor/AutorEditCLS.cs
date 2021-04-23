using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace segundoBlazor.Shared.Autor
{
    public class AutorEditCLS
    {
        public int idAutor { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre dle autor ")]
        [MaxLength(100, ErrorMessage = "La longitud debe ser de 100")]
        [MinLength(2, ErrorMessage = "La longitud es muy pequeña.")]
        public string nombreAutor { get; set; }
        [Required(ErrorMessage = "Debe ingresar el primero apellido del autor ")]
        [MaxLength(150, ErrorMessage = "La longitud debe ser de 100")]
        [MinLength(3, ErrorMessage = "La longitud es muy pequeña.")]
        public string aPaterno { set; get; }
        [Required(ErrorMessage = "Debe ingresar el segundo apellido del autor ")]
        [MaxLength(150, ErrorMessage = "La longitud debe ser de 100")]
        [MinLength(3, ErrorMessage = "La longitud es muy pequeña.")]
        public string aMaterno { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el sexo")]
        public string idSexo { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el país")]
        public string idPais { get; set; }
        [Required(ErrorMessage = "Debes ingresar una breve descripción")]
        [MaxLength(500, ErrorMessage = "La longitud debe ser de 100")]
        [MinLength(10, ErrorMessage = "La longitud es muy pequeña.")]
        public string description { get; set; }
    }
}
