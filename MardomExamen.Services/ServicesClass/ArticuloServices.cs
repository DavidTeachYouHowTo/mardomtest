using MardomExamen.Domain.Entities;
using MardomExamen.Repository.RepositoryClass;
using MardomExamen.Services.ArticuloValidaciones;
using MardomExamen.Services.Interface;
using System;
using System.Collections.Generic;

namespace MardomExamen.Services.ServicesClass
{
    public class ArticuloServices : IArticuloServices
    {
        public List<Articulos> ObtenerArticulos()
        {
            ArticuloRepository articuloRepository = new ArticuloRepository();

            List<Articulos> listadoArticulos = new List<Articulos>();

            try
            {
                listadoArticulos = articuloRepository.ObtenerArticulos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoArticulos;
        }

        public Articulos ObtenerArticuloPorId(int? id)
        {
            ArticuloRepository ArticuloRepository = new ArticuloRepository();

            Articulos listadoArticulos = new Articulos();

            try
            {
                listadoArticulos = ArticuloRepository.ObtenerArticuloId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoArticulos;
        }

        public bool Save(Articulos Articulo)
        {
            ArticuloRepository articuloRepository = new ArticuloRepository();
            bool articuloGuardado = false;
            bool existeNombreArticulo = false;

            try
            {
                existeNombreArticulo = ArticuloValidacionNombre.ExisteNombreArticulo(Articulo.Articulo);

                if (existeNombreArticulo)
                {
                    throw new Exception(string.Format("El nombre: {0} ya esta en uso, por favor asignar otro nombre.", Articulo.Articulo));
                }

                articuloGuardado = articuloRepository.Save(Articulo);
            }
            catch (Exception ex)
            {
                articuloGuardado = false;

                throw new Exception(ex.Message);
            }

            return articuloGuardado;
        }

        public bool Update(Articulos articuloUpdate)
        {
            ArticuloRepository articuloRepository = new ArticuloRepository();
            bool articuloActualizado = false;
            bool existeNombreArticulo = false;

            try
            {
                Articulos articuloConsulta = new Articulos();
                articuloConsulta = articuloRepository.ObtenerArticuloId(articuloUpdate.ID);

                if (articuloUpdate.Articulo != articuloConsulta.Articulo)
                {
                    existeNombreArticulo = ArticuloValidacionNombre.ExisteNombreArticulo(articuloUpdate.Articulo);

                    if (existeNombreArticulo)
                    {
                        throw new Exception(string.Format("El nombre: {0} ya esta en uso, por favor asignar otro nombre.", articuloUpdate.Articulo));
                    }
                }

                articuloActualizado = articuloRepository.Update(articuloUpdate);
            }
            catch (Exception ex)
            {
                articuloActualizado = false;

                throw new Exception(ex.Message);
            }

            return articuloActualizado;
        }
    }
}
