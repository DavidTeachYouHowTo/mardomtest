using MardomExamen.Domain.Entities;
using MardomExamen.Repository.RepositoryClass;
using MardomExamen.Services.Interface;
using System;
using System.Collections.Generic;

namespace MardomExamen.Services.ServicesClass
{
    public class ArticuloAlmacenesServices : IArticuloAlmacenService
    {
        public List<vwArticuloAlmaces> ObtenerArticulosAlmacen()
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();
            List<vwArticuloAlmaces> listadoArticulosAlmacen = new List<vwArticuloAlmaces>();

            try
            {
                listadoArticulosAlmacen = articuloAlmacenRepository.ObtenerArticulosAlmacen();
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener el listado de Articulos Almacen");
            }

            return listadoArticulosAlmacen;
        }

        public List<Articulos> ObtenerArticulos()
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();

            List<Articulos> listadoArticulos = new List<Articulos>();

            try
            {
                listadoArticulos = articuloAlmacenRepository.ObtenerArticulos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoArticulos;
        }

        public List<Almacenes> ObtenerAlmacenes()
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();

            List<Almacenes> listadoAlmacenes = new List<Almacenes>();

            try
            {
                listadoAlmacenes = articuloAlmacenRepository.ObtenerAlmacenes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoAlmacenes;
        }

        public string ObtenerNombreArticulo(int articuloId)
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();

            string nombreArticulo = "";

            try
            {
                nombreArticulo = articuloAlmacenRepository.ObtenerNombreArticulo(articuloId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nombreArticulo;
        }

        public string ObtenerNombreAlmacen(int almacenId)
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();

            string nombreAlmacen = "";

            try
            {
                nombreAlmacen = articuloAlmacenRepository.ObtenerNombreAlmacen(almacenId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nombreAlmacen;
        }

        public ArticuloAlmacen ObtenerArticuloAlmacenPorId(int? id)
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();
            ArticuloAlmacen listadoArticulosAlmacen = new ArticuloAlmacen();

            try
            {
                listadoArticulosAlmacen = articuloAlmacenRepository.ObtenerArticuloAlmacenPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoArticulosAlmacen;
        }

        public bool Save(ArticuloAlmacen articuloAlmacenes)
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();
            bool articuloGuardado = false;
            int capacidadAlmacen = 0;
            int cantidadArticuloAlmacen = 0;
            int totalArticuloAlmacen = 0;
            bool existeArticuloEnAlmacen = false;
            string nombreArticulo = "";
            string nombreAlmacen = "";

            try
            {
                nombreArticulo = ObtenerNombreArticulo(articuloAlmacenes.Articulo_ID);
                nombreAlmacen = ObtenerNombreAlmacen(articuloAlmacenes.Almacen_ID);
                capacidadAlmacen = articuloAlmacenRepository.ObtenerCapacidadEnAlmacen(articuloAlmacenes.Almacen_ID);
                cantidadArticuloAlmacen = articuloAlmacenRepository.ObtenerCantidadArticuloEnAlmacen(articuloAlmacenes.Almacen_ID);
                totalArticuloAlmacen = cantidadArticuloAlmacen + (articuloAlmacenes.Cantidad != null ? Convert.ToInt32(articuloAlmacenes.Cantidad) : 0);
                existeArticuloEnAlmacen = articuloAlmacenRepository.ExisteArticuloEnAlmacen(articuloAlmacenes.Almacen_ID, articuloAlmacenes.Articulo_ID);

                if (existeArticuloEnAlmacen)
                {
                    throw new Exception(string.Format("El articulo: {0} ya esta agregado en el almacen seleccionado, por favor asignar otro articulo.", nombreArticulo));
                }
                else if(totalArticuloAlmacen > capacidadAlmacen)
                {
                    throw new Exception(string.Format("El almacen: {0}, ha llegado a su capacidad maxima: {1}, por favor, escoger otro almacen.", nombreAlmacen, capacidadAlmacen));
                }

                articuloGuardado = articuloAlmacenRepository.Save(articuloAlmacenes);
            }
            catch (Exception ex)
            {
                articuloGuardado = false;

                throw new Exception(ex.Message);
            }

            return articuloGuardado;
        }

        public bool Update(ArticuloAlmacen articuloAlmacenes)
        {
            ArticuloAlmacenRepository articuloAlmacenRepository = new ArticuloAlmacenRepository();
            bool articuloActualizado = false;
            int capacidadAlmacen = 0;
            int cantidadArticuloAlmacen = 0;

            try
            {
                capacidadAlmacen = articuloAlmacenRepository.ObtenerCapacidadEnAlmacen(articuloAlmacenes.Almacen_ID);
                cantidadArticuloAlmacen = articuloAlmacenRepository.ObtenerCantidadArticuloEnAlmacen(articuloAlmacenes.Almacen_ID);

                if (cantidadArticuloAlmacen > 0)
                {
                    throw new Exception(string.Format("El articulo: {0} ya esta agregado en el almacen seleccionado, por favor asignar otro articulo.", articuloAlmacenes.Articulo));
                }
                else if (cantidadArticuloAlmacen == capacidadAlmacen)
                {
                    throw new Exception(string.Format("El almacen: {0}, ha llegado a su capacidad maxima: {1}, por favor, escoger otro almacen.", articuloAlmacenes.Almacen, capacidadAlmacen));
                }

                articuloActualizado = articuloAlmacenRepository.Update(articuloAlmacenes);
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
