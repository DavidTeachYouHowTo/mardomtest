using MardomExamen.Domain.Entities;
using System.Collections.Generic;

namespace MardomExamen.Services.Interface
{
    public interface IArticuloServices
    {
        List<Articulos> ObtenerArticulos();
        Articulos ObtenerArticuloPorId(int? id);
        bool Save(Articulos Articulo);
        bool Update(Articulos Articulo);
    }
}
