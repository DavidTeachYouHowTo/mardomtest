using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MardomExamen.Domain.Entities
{
    public partial class vwArticuloAlmaces
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [StringLength(50)]
        public string Articulo { get; set; }

        [StringLength(50)]
        public string Almacen { get; set; }

        [Display(Name = "Stock")]
        public int? Cantidad { get; set; }

        public int Capacidad { get; set; }
    }
}
