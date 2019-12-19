using MardomExamen.Domain.Entities;
using MardomExamen.Repository.RepositoryClass;
using MardomExamen.Services.AlmacenValidaciones;
using MardomExamen.Services.Interface;
using System;
using System.Collections.Generic;

namespace MardomExamen.Services.ServicesClass
{
    public class AlmacenServices : IAlmacenServices
    {
        public List<Almacenes> ObtenerAlmacenes()
        {
            AlmacenRepository almacenRepository = new AlmacenRepository();

            List<Almacenes> listadoAlmacenes = new List<Almacenes>();

            try
            {
                listadoAlmacenes = almacenRepository.ObtenerAlmacenes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoAlmacenes;
        }       
        
        public Almacenes ObtenerAlmacenPorId(int? id)
        {
            AlmacenRepository almacenRepository = new AlmacenRepository();

            Almacenes listadoAlmacenes = new Almacenes();

            try
            {
                listadoAlmacenes = almacenRepository.ObtenerAlmacenId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoAlmacenes;
        }

        public bool Save(Almacenes almacen)
        {
            AlmacenRepository almacenRepository = new AlmacenRepository();
            bool almacenGuardado = false;
            bool existeNombreAlmacen = false;

            try
            {
                existeNombreAlmacen = AlmacenValidacionNombre.ExisteNombreAlmacen(almacen.Almacen);

                if (existeNombreAlmacen)
                {
                    throw new Exception(string.Format("El nombre: {0} ya esta en uso, por favor asignar otro nombre.", almacen.Almacen));
                }

                almacenGuardado = almacenRepository.Save(almacen);
            }
            catch (Exception ex)
            {
                almacenGuardado = false;

                throw new Exception(ex.Message);
            }

            return almacenGuardado;
        }

        public bool Update(Almacenes almacen)
        {
            AlmacenRepository almacenRepository = new AlmacenRepository();
            bool almacenActualizado = false;
            bool existeNombreAlmacen = false;

            try
            {
                Almacenes almacenConsulta = new Almacenes();
                almacenConsulta = almacenRepository.ObtenerAlmacenId(almacen.ID);

                if (almacen.Almacen != almacenConsulta.Almacen)
                {
                    existeNombreAlmacen = AlmacenValidacionNombre.ExisteNombreAlmacen(almacen.Almacen);

                    if (existeNombreAlmacen)
                    {
                        throw new Exception(string.Format("El nombre: {0} ya esta en uso, por favor asignar otro nombre.", almacen.Almacen));
                    }
                }

                almacenActualizado = almacenRepository.Update(almacen);
            }
            catch (Exception ex)
            {
                almacenActualizado = false;

                throw new Exception(ex.Message);
            }

            return almacenActualizado;
        }
    }
}
