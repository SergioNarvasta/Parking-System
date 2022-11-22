using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSIST.Models.Entidades
{
    public class OrdenCompraDet
    {
        [Key]
        public int idOrdenCompraDet { get; set; }

        [Display(Name = "Descripcion Articulo")]
        [Required(ErrorMessage = "Debe de ingresar el nombre del articulo")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Codigo Rapido")]
        [Required(ErrorMessage = "Debe de ingresar el codigo rapido del articulo")]
        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public string CodigoRapido { get; set; }


        [Display(Name = "Unidad de Medida")]
        [Required(ErrorMessage = "Debe de ingresar la unidad de medida del articulo")]
        [MaxLength(8, ErrorMessage = "El campo no debe de tener mas de 8 caracteres")]
        public string UnidadMedida { get; set; }


        public float Cantidad { get; set; }

        public float Precio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int idOrdenCompraCab { get; set; }
        public virtual OrdenCompraCab OrdenCompraCab { get; set; }





    }
}
