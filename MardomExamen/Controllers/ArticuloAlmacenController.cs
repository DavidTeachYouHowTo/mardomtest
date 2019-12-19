using MardomExamen.Domain.Entities;
using MardomExamen.Services.ServicesClass;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MardomExamen.Controllers
{
    public class ArticuloAlmacenController : Controller
    {
        // GET: ArticuloAlmacen
        public ActionResult Index()
        {
            ArticuloAlmacenesServices articuloAlmacenServices = new ArticuloAlmacenesServices();
            List<vwArticuloAlmaces> listadoArticuloAlmacen = new List<vwArticuloAlmaces>();

            listadoArticuloAlmacen = articuloAlmacenServices.ObtenerArticulosAlmacen();


            return View(listadoArticuloAlmacen);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now.ToString();
            ArticuloAlmacenesServices articuloAlmacenServices = new ArticuloAlmacenesServices();

            ViewBag.Almacen_ID = new SelectList(articuloAlmacenServices.ObtenerAlmacenes(), "ID", "Almacen");
            ViewBag.Articulo_ID = new SelectList(articuloAlmacenServices.ObtenerArticulos(), "ID", "Articulo");

            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticuloAlmacen articuloAlmacenCreate)
        {
            ArticuloAlmacenesServices articuloAlmacenServices = new ArticuloAlmacenesServices();
            bool articuloAlmacenGuardado = false;
            

            try
            {
                if (ModelState.IsValid)
                {
                    articuloAlmacenCreate.Fecha = DateTime.Now;
                    articuloAlmacenGuardado = articuloAlmacenServices.Save(articuloAlmacenCreate);

                    if (articuloAlmacenGuardado)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }

            ViewBag.Almacen_ID = new SelectList(articuloAlmacenServices.ObtenerAlmacenes(), "ID", "Almacen", articuloAlmacenCreate.Almacen_ID);
            ViewBag.Articulo_ID = new SelectList(articuloAlmacenServices.ObtenerArticulos(), "ID", "Articulo", articuloAlmacenCreate.Articulo_ID);

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ArticuloAlmacenesServices articuloAlmacenServices = new ArticuloAlmacenesServices();
            ArticuloAlmacen articuloAlmacen = new ArticuloAlmacen();

            try
            {
                if (id != null)
                {                    
                    articuloAlmacen = articuloAlmacenServices.ObtenerArticuloAlmacenPorId(id);

                    ViewBag.Almacen_ID = new SelectList(articuloAlmacenServices.ObtenerAlmacenes(), "ID", "Almacen", articuloAlmacen.Almacen_ID);
                    ViewBag.Articulo_ID = new SelectList(articuloAlmacenServices.ObtenerArticulos(), "ID", "Articulo", articuloAlmacen.Articulo_ID);

                    return View(articuloAlmacen);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }           

            return View();
        }

        [HttpPost]
        public ActionResult Edit(ArticuloAlmacen articuloEdit)
        {
            ArticuloAlmacenesServices articuloAlmacenServices = new ArticuloAlmacenesServices();
            bool articuloActualizado = false;

            try
            {
                if (ModelState.IsValid)
                {
                    articuloActualizado = articuloAlmacenServices.Update(articuloEdit);

                    if (articuloActualizado)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }

            ViewBag.Almacen_ID = new SelectList(articuloAlmacenServices.ObtenerAlmacenes(), "ID", "Almacen", articuloEdit.Almacen_ID);
            ViewBag.Articulo_ID = new SelectList(articuloAlmacenServices.ObtenerArticulos(), "ID", "Articulo", articuloEdit.Articulo_ID);

            return View();
        }
    }
}