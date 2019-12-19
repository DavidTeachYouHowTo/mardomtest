using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MardomExamen.Domain.Entities
{
    [Table("vwCantidadArticulosAlmacen")]
    public class vwCantidadArticulosAlmacen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Almacen_ID { get; set; }

        [StringLength(50)]
        public string Almacen { get; set; }

        public int? Cantidad { get; set; }
    }
}
