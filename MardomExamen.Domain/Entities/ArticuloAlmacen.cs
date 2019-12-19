using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardomExamen.Domain.Entities
{
  
    [Table("ArticuloAlmacen")]
    public partial class ArticuloAlmacen
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [Display(Name = "Artículo")]
        public int Articulo_ID { get; set; }

        [Display(Name = "Almacén")]
        public int Almacen_ID { get; set; }
        [Display(Name ="Stock")]
        public int? Cantidad { get; set; }
        public virtual Articulos Articulo { get; set; }
        public virtual Almacenes Almacen { get; set; }
    }
}
