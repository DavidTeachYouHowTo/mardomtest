using MardomExamen.Repository.RepositoryClass;
using System;

namespace MardomExamen.Services.AlmacenValidaciones
{
    public class AlmacenValidacionNombre
    {
        public static bool ExisteNombreAlmacen(string nombreAlmacen)
        {
            bool existeNombreAlmacen = false;

            try
            {
                AlmacenRepository almacenRepository = new AlmacenRepository();
                existeNombreAlmacen = almacenRepository.ExisteNombreAlmacen(nombreAlmacen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return existeNombreAlmacen;
        }
    }
}
