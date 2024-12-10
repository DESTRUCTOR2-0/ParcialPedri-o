using ParcialPedriño.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialPedriño.Controllers
{
    public class LibrosController : Controller
    {
        // GET: Libros
        public ActionResult Index()
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Libros.ToList());
            }
        }

        // GET: Libros/Details/5
        public ActionResult Details(int id)
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Libros.Where(x => x.LibroId == id).FirstOrDefault());
            }
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                int maxLibroId = contexto.Libros.Max(r => r.LibroId);
                var model = new Libros
                {
                    LibroId = maxLibroId + 1
                };
                return View(model);
            }
        }

        // POST: Libros/Create
        [HttpPost]
        public ActionResult Create(Libros libros)
        {
            try
            {
                using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
                {
                    // Lógica de inserción
                    var newLibro = new Libros
                    {
                        LibroId = libros.LibroId,
                        titulo = libros.titulo,
                        autor = libros.autor,
                        duracion = libros.duracion,
                        clasificacion = libros.clasificacion,
                        fecha_publicacion = libros.fecha_publicacion,
                        CategoriaId = libros.CategoriaId
                    };
                    contexto.Libros.Add(newLibro);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Libros.Where(x => x.LibroId == id).FirstOrDefault());
            }
        }

        // POST: Libros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Libros libros)
        {
            try
            {
                using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
                {
                    // Usando el espacio de nombres correcto para EF 6
                    contexto.Entry(libros).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
            {
                return View(contexto.Libros.Where(x => x.LibroId == id).FirstOrDefault());
            }
        }

        // POST: Libros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (TiendaLibrosEntities3 contexto = new TiendaLibrosEntities3())
                {
                    Libros objLibro = contexto.Libros.Where(x => x.LibroId == id).FirstOrDefault();
                    contexto.Libros.Remove(objLibro);
                    contexto.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }

}
