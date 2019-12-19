using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MardomExamen.Domain.Entities
{
    [Table("Articulos")]
    public partial class Articulos
    {
        public Articulos()
        {
            ListadoArticulosAlmacenes = new HashSet<ArticuloAlmacen>();
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre del artículo es requerido")]
        [Display(Name = "Artículo")]
        [StringLength(50, ErrorMessage = "El nombre del artículo debe ser menor a 50 caracteres")]
        public string Articulo { get; set; }

        [Required(ErrorMessage = "El código del artículo es requerido")]
        [Display(Name = "Código")]
        [StringLength(20, ErrorMessage = "El código del artículo debe ser menor a 20 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El precio del artículo del artículo es requerido")]
        public decimal Precio { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<ArticuloAlmacen> ListadoArticulosAlmacenes { get; set; } 
    }
}
