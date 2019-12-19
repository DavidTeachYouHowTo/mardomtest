using MardomExamen.Domain.Entities;
using System.Collections.Generic;

namespace MardomExamen.Repository.Interface
{
    public interface IAlmacenRepository
    {
        List<Almacenes> ObtenerAlmacenes();
        Almacenes ObtenerAlmacenId(int? id);
        bool ExisteNombreAlmacen(string nombreAlmacen);
        bool Save(Almacenes almacen);
        bool Update(Almacenes almacen);
    }
}
