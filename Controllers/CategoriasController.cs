using ParcialPedriño.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialPedriño.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Categorias.ToList());
            }
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
            }
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                int maxCategoriasId = contexto.Categorias.Max(r => r.CategoriaId);
                var model = new Categorias
                {
                    CategoriaId = maxCategoriasId + 1
                };
                return View(model);
            }
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categorias categoria)
        {
            try
            {
                using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
                {
                    // Lógica de inserción
                    var newCategoria = new Categorias
                    {
                        CategoriaId = categoria.CategoriaId,
                        nombre = categoria.nombre,
                        descripcion = categoria.descripcion,
                        fecha_creacion = categoria.fecha_creacion,
                        activo = categoria.activo,
                        pais_origen = categoria.pais_origen
                    };

                    contexto.Categorias.Add(newCategoria);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
            }
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categorias categoria)
        {
            try
            {
                using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
                {
                    contexto.Entry(categoria).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
            }
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
                {
                    Categorias objCategoria = contexto.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault();
                    contexto.Categorias.Remove(objCategoria);
                    contexto.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
