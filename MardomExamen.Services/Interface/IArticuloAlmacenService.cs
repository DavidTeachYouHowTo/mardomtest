using MardomExamen.Domain.Entities;
using System.Collections.Generic;

namespace MardomExamen.Services.Interface
{
    public interface IArticuloAlmacenService
    {
        List<vwArticuloAlmaces> ObtenerArticulosAlmacen();
        List<Articulos> ObtenerArticulos();
        List<Almacenes> ObtenerAlmacenes();
        string ObtenerNombreArticulo(int articuloId);
        string ObtenerNombreAlmacen(int almacenId);
        ArticuloAlmacen ObtenerArticuloAlmacenPorId(int? id);
        bool Save(ArticuloAlmacen articuloAlmacenes);
        bool Update(ArticuloAlmacen articuloAlmacenes);
    }
}
