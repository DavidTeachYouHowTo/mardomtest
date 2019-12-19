using MardomExamen.Domain.Entities;
using System.Collections.Generic;

namespace MardomExamen.Repository.Interface
{
    public interface IArticuloAlmacenRepository
    {
        List<vwArticuloAlmaces> ObtenerArticulosAlmacen();
        ArticuloAlmacen ObtenerArticuloAlmacenPorId(int? id);
        List<Articulos> ObtenerArticulos();
        List<Almacenes> ObtenerAlmacenes();
        string ObtenerNombreArticulo(int articuloId);
        string ObtenerNombreAlmacen(int almacenId);
        int ObtenerCapacidadEnAlmacen(int almacenId);
        int ObtenerCantidadArticuloEnAlmacen(int almacenId);
        bool ExisteArticuloEnAlmacen(int almacenId, int articuloId);
        bool Save(ArticuloAlmacen articuloAlmacenes);
        bool Update(ArticuloAlmacen articuloAlmacenes);
    }
}
