using MardomExamen.Domain.Entities;
using System.Collections.Generic;

namespace MardomExamen.Repository.Interface
{
    public interface IArticuloRepository
    {
        List<Articulos> ObtenerArticulos();
        Articulos ObtenerArticuloId(int? id);

        bool ExisteNombreArticulo(string nombreArticulo);

        bool Save(Articulos Articulo);

        bool Update(Articulos Articulo);
    }
}
