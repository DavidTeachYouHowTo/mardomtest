using MardomExamen.Domain.Entities;
using MardomExamen.Repository.Interface;
using MardomExamen.Repository.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MardomExamen.Repository.RepositoryClass
{
    public class ArticuloRepository : IArticuloRepository
    {
        public List<Articulos> ObtenerArticulos()
        {
            List<Articulos> listadoArticulos = new List<Articulos>();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    listadoArticulos = db.Articulos.ToList();
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

        public Articulos ObtenerArticuloId(int? id)
        {
            Articulos Articulo = new Articulos();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    Articulo = db.Articulos.Find(id);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al tratar de obtener el articulo");
            }

            return Articulo;
        }

        public bool ExisteNombreArticulo(string nombreArticulo)
        {
            bool existeNombreArticulo = false;

            Articulos Articulo = new Articulos();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    Articulo = db.Articulos.Where(m => m.Articulo == nombreArticulo).FirstOrDefault();
                }

                existeNombreArticulo = (Articulo != null) ? true : false;
            }
            catch (Exception)
            {
                throw new Exception("Error al tratar de validar si el nombre del articulo esta registrado en la base de datos");
            }

            return existeNombreArticulo;
        }

        public bool Save(Articulos Articulo)
        {
            bool articuloGuardado = false;

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    db.Articulos.Add(Articulo);
                    db.SaveChanges();
                    articuloGuardado = true;
                }
            }
            catch (Exception)
            {
                articuloGuardado = false;

                throw new Exception("Error al tratar de guardar el articulo");
            }

            return articuloGuardado;
        }

        public bool Update(Articulos Articulo)
        {
            bool articuloActualizado = false;

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    db.Entry(Articulo).State = System.Data.Entity.EntityState.Modified;
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
