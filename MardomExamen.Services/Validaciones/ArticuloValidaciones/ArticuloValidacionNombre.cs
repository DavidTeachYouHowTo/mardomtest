using MardomExamen.Repository.RepositoryClass;
using System;

namespace MardomExamen.Services.ArticuloValidaciones
{
    public class ArticuloValidacionNombre
    {
        public static bool ExisteNombreArticulo(string nombreAlmacen)
        {
            bool existeNombreArticulo = false;

            try
            {
                ArticuloRepository articuloRepository = new ArticuloRepository();
                existeNombreArticulo = articuloRepository.ExisteNombreArticulo(nombreAlmacen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return existeNombreArticulo;
        }
    }
}
