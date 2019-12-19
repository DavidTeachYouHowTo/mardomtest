using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MardomExamen.Domain.Entities
{
    [Table("Almacenes")]
    public partial class Almacenes
    {
        public Almacenes()
        {
            ListadoArticuloAlmacen = new HashSet<ArticuloAlmacen>();
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre del almacén es requerido")]
        [Display(Name="Almacén")]        
        [MaxLength(50, ErrorMessage ="El nombre del almacén debe ser menor a 50 caracteres")]
        public string Almacen { get; set; }

        [Required(ErrorMessage = "La ubicación del almacén es requerida")]
        [Display(Name = "Ubicación")]
        [StringLength(50, ErrorMessage = "El nombre de la ubicación del almacén debe ser menor a 50 caracteres")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "La capacidad del almacén es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad del almacén debe ser mayor a cero")]
        public int Capacidad { get; set; }

        public virtual ICollection<ArticuloAlmacen> ListadoArticuloAlmacen { get; set; }
    }
}
