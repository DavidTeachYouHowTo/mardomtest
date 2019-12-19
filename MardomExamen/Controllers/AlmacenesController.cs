using MardomExamen.Domain.Entities;
using MardomExamen.Services.ServicesClass;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MardomExamen.Controllers
{
    public class AlmacenesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            AlmacenServices almacenServices = new AlmacenServices();

            List<Almacenes> listadoAlmacenes = almacenServices.ObtenerAlmacenes();

            return View(listadoAlmacenes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Almacenes almacenCreate)
        {
            bool almacenGuardado = false;

            try
            {
                if (ModelState.IsValid)
                {
                    AlmacenServices almacenServices = new AlmacenServices();
                    almacenGuardado = almacenServices.Save(almacenCreate);

                    if (almacenGuardado)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Almacenes almacen = new Almacenes();

            try
            {
                if (id != null)
                {
                    AlmacenServices almacenServices = new AlmacenServices();
                    almacen = almacenServices.ObtenerAlmacenPorId(id);

                    return View(almacen);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Almacenes almacenEdit)
        {
            bool almacenActualizado = false;

            try
            {
                if (ModelState.IsValid)
                {
                    AlmacenServices almacenServices = new AlmacenServices();
                    almacenActualizado = almacenServices.Update(almacenEdit);

                    if (almacenActualizado)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }

            return View();
        }
    }
}
