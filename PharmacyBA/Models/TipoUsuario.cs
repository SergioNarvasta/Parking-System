using System.ComponentModel.DataAnnotations;
namespace PharmacyBA.Models

{
    public class TipoUsuario
    {
        [Key]
        public int Tiu_codepk { get; set; }

        [MaxLength (45)]
        public String ?Tiu_desc { get; set; }
    }
}
