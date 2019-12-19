using MardomExamen.Domain.Entities;
using System.Collections.Generic;

namespace MardomExamen.Services.Interface
{
    public interface IAlmacenServices
    {
        List<Almacenes> ObtenerAlmacenes();
        Almacenes ObtenerAlmacenPorId(int? id);
        bool Save(Almacenes almacen);
        bool Update(Almacenes almacen);
    }
}
