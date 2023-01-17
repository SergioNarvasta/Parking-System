using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models.Entities
{
    public class DetalleVenta
    {
        [Key]
        public int CodDetVenta { get; set; }
        public int Cantidad     { get; set; }
        public Double Precio    { get; set; }
        public Double Subtotal  { get; set; }
        public Double IGV       { get; set; }

        //ForeignKey Key
        public int CodVenta { get; set; }
        public virtual Venta Venta { get; set; }

    }
}
