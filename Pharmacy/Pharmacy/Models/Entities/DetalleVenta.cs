using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models.Entities
{
    public class DetalleVenta
    {
        [Key]
        public int IdDetVenta   { get; set; }
        public int IdProducto   { get; set; }
        public int Cantidad     { get; set; }
        //public Double Precio  { get; set; }
        public Double Subtotal  { get; set; }
        public Double IGV       { get; set; }
        
        public int RegCliente   { get; set; } //Flag para sabser ri se registro el cliente(1) o no(0)
        public int IdCliente    { get; set; }
        public string NomCliente{ get; set; }

        //ForeignKey Key
        public int CodVenta { get; set; }
        public virtual Venta Venta { get; set; }

    }
}
