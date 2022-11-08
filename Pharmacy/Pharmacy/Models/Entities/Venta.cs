using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models.Entities
{
    public class Venta
    {
        [Key]
        public int Codventa { get; set; }
        public int Descuento { get; set; } = 0;
        public Double Total { get; set; } = 0;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string ?TipoPago { get; set; }

        //Foreign Keys
        public int CodCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        //Referencia de Relacion 
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

    }
}
