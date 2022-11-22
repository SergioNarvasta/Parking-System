using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSIST.Models.Entidades
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }


        [Display(Name = "Nombre de Producto")]
        [Required(ErrorMessage = "Debe de ingresar el nombre del Producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres ")]
        public string Nombre { get; set; }

        [Display(Name = "Codigo del Producto")]
        [Required(ErrorMessage = "Debe de ingresar el codigo del producto")]
        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Existencias")]
        [Required(ErrorMessage = "Debe ingresar el stock del producto")]
        public decimal Stock { get; set; }

        [Display(Name = "Precio del Producto")]
        [Required(ErrorMessage = "Debe de ingresar el precio del producto")]
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        


    }
}
