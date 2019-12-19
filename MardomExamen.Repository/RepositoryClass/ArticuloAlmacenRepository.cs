using MardomExamen.Domain.Entities;
using MardomExamen.Repository.Interface;
using MardomExamen.Repository.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MardomExamen.Repository.RepositoryClass
{
    public class ArticuloAlmacenRepository : IArticuloAlmacenRepository
    {
        public List<vwArticuloAlmaces> ObtenerArticulosAlmacen()
        {
            List<vwArticuloAlmaces> listadoArticulosAlmacen = new List<vwArticuloAlmaces>();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {

                    listadoArticulosAlmacen = db.vwArticuloAlmaces.ToList();
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener el listado de Articulos Almacen");
            }

            return listadoArticulosAlmacen;
        }

        public ArticuloAlmacen ObtenerArticuloAlmacenPorId(int? id)
        {
            ArticuloAlmacen Articulo = new ArticuloAlmacen();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    Articulo = db.ArticuloAlmacen.Find(id);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al tratar de obtener el articulo almacen");
            }

            return Articulo;
        }

        public List<Articulos> ObtenerArticulos()
        {
            List<Articulos> listadoArticulos = new List<Articulos>();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    listadoArticulos = db.Articulos.Where(a=>a.Activo == true).ToList();
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener el listado de Articulos");
            }

            return listadoArticulos;
        }

        public List<Almacenes> ObtenerAlmacenes()
        {
            List<Almacenes> listadoAlmacenes = new List<Almacenes>();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    listadoAlmacenes = db.Almacenes.ToList();
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener el listado de almacenes");
            }

            return listadoAlmacenes;
        }

        public string ObtenerNombreArticulo(int articuloId)
        {
            string nombreArticulo = "";
            Articulos articulo = new Articulos();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    articulo = db.Articulos.Find(articuloId);
                }

                if (articulo != null)
                {
                    nombreArticulo = articulo.Articulo;
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener el nombre del Articulo");
            }

            return nombreArticulo;
        }

        public string ObtenerNombreAlmacen(int almacenId)
        {
            string nombreAlmacen = "";
            Almacenes almacen = new Almacenes();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    almacen = db.Almacenes.Find(almacenId);
                }

                if (almacen != null)
                {
                    nombreAlmacen = almacen.Almacen;
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener el nombre del Almacen");
            }

            return nombreAlmacen;
        }

        public int ObtenerCapacidadEnAlmacen(int almacenId)
        {
            int capacidadEnAlmacen = 0;

            Almacenes almacen = new Almacenes();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    almacen = db.Almacenes.Where(m => m.ID == almacenId).FirstOrDefault();
                }

                capacidadEnAlmacen = (almacen != null) ? almacen.Capacidad : 0;
            }
            catch (Exception)
            {
                throw new Exception("Error al tratar de validar si el articulo esta registrado en el almacen seleccionado");
            }

            return capacidadEnAlmacen;
        }

        public int ObtenerCantidadArticuloEnAlmacen(int almacenId)
        {
            int cantidadArticuloEnAlmacen = 0;

            vwCantidadArticulosAlmacen vwCantidadArticuloAlmacen = new vwCantidadArticulosAlmacen();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    vwCantidadArticuloAlmacen = db.vwCantidadArticulosAlmacen.Find(almacenId);
                }

                cantidadArticuloEnAlmacen = (vwCantidadArticuloAlmacen != null) ? Convert.ToInt32(vwCantidadArticuloAlmacen.Cantidad) : 0;
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de obtener la cantidad de articulos en el almacen seleccionado");
            }

            return cantidadArticuloEnAlmacen;
        }

        public bool ExisteArticuloEnAlmacen(int almacenId, int articuloId)
        {
            bool existeArticuloEnAlmacen = false;

            List<ArticuloAlmacen> listadoArticuloAlmacen = new List<ArticuloAlmacen>();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    listadoArticuloAlmacen = db.ArticuloAlmacen.Where(m => m.Almacen_ID == almacenId && m.Articulo_ID == articuloId).ToList();
                }

                existeArticuloEnAlmacen = (listadoArticuloAlmacen != null) ? listadoArticuloAlmacen.Count > 0 : false;
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                throw new Exception("Error al tratar de validar si el articulo esta registrado en el almacen seleccionado");
            }

            return existeArticuloEnAlmacen;
        }

        public bool Save(ArticuloAlmacen articuloAlmacenes)
        {
            bool articuloGuardado = false;

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    db.ArticuloAlmacen.Add(articuloAlmacenes);
                    db.SaveChanges();
                    articuloGuardado = true;
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
                string inner = ex.InnerException.ToString();

                articuloGuardado = false;

                throw new Exception("Error al tratar de guardar el articulo");
            }

            return articuloGuardado;
        }

        public bool Update(ArticuloAlmacen articuloAlmacenes)
        {
            bool articuloActualizado = false;

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    db.Entry(articuloAlmacenes).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    articuloActualizado = true;
                }
            }
            catch (Exception)
            {
                articuloActualizado = false;

                throw new Exception("Error al tratar de actualizar el articulo");
            }

            return articuloActualizado;
        }
    }
}
