using MardomExamen.Domain.Entities;
using MardomExamen.Repository.Interface;
using MardomExamen.Repository.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MardomExamen.Repository.RepositoryClass
{
    public class AlmacenRepository : IAlmacenRepository
    {
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

        public Almacenes ObtenerAlmacenId(int? id)
        {
            Almacenes almacen = new Almacenes();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    almacen = db.Almacenes.Find(id);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al tratar de obtener el almacén");
            }

            return almacen;
        }

        public bool ExisteNombreAlmacen(string nombreAlmacen)
        {
            bool existeNombreAlmacen = false;

            Almacenes almacen = new Almacenes();

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    almacen = db.Almacenes.Where(m=>m.Almacen == nombreAlmacen).FirstOrDefault();
                }

                existeNombreAlmacen = (almacen != null) ? true : false;
            }
            catch (Exception)
            {
                throw new Exception("Error al tratar de validar si el nombre del almacén esta registrado en la base de datos");
            }

            return existeNombreAlmacen;
        }

        public bool Save(Almacenes almacen)
        {
            bool almacenGuardado = false;

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    db.Almacenes.Add(almacen);
                    db.SaveChanges();
                    almacenGuardado = true;
                }
            }
            catch (Exception)
            {
                almacenGuardado = false;

                throw new Exception("Error al tratar de guardar el almacén");
            }

            return almacenGuardado;
        }

        public bool Update(Almacenes almacen)
        {
            bool almacenActualizado = false;

            try
            {
                using (DbMardomExamen db = new DbMardomExamen())
                {
                    db.Entry(almacen).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    almacenActualizado = true;
                }
            }
            catch (Exception)
            {
                almacenActualizado = false;

                throw new Exception("Error al tratar de actualizar el almacén");
            }

            return almacenActualizado;
        }
    }
}
