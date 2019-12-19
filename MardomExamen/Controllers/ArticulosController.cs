using MardomExamen.Domain.Entities;
using MardomExamen.Services.ServicesClass;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MardomExamen.Controllers
{
    public class ArticulosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ArticuloServices articuloServices = new ArticuloServices();

            List<Articulos> listadoArticulos = articuloServices.ObtenerArticulos();

            return View(listadoArticulos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Articulos articuloCreate)
        {
            bool articuloGuardado = false;

            try
            {
                if (ModelState.IsValid)
                {
                    articuloCreate.Activo = true;

                    ArticuloServices articuloServices = new ArticuloServices();
                    articuloGuardado = articuloServices.Save(articuloCreate);

                    if (articuloGuardado)
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
            Articulos articulo = new Articulos();

            try
            {
                if (id != null)
                {
                    ArticuloServices articuloServices = new ArticuloServices();
                    articulo = articuloServices.ObtenerArticuloPorId(id);

                    return View(articulo);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Articulos articuloEdit)
        {
            bool articuloActualizado = false;

            try
            {
                if (ModelState.IsValid)
                {
                    ArticuloServices articuloServices = new ArticuloServices();
                    articuloActualizado = articuloServices.Update(articuloEdit);

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

            return View();
        }
    }
}