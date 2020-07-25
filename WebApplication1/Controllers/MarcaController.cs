using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        BDAutosEntities db = new BDAutosEntities();
        public ActionResult Index()
        {
            var lista = db.marca.ToList();
            return View(lista);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int id)
        {
            marca m = db.marca.FirstOrDefault(x => x.id_marca == id);
            return View(m);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                marca m = new marca();
                m.nombre = collection["nombre"];
                m.estado = collection["estado"];
                db.marca.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            marca m = db.marca.FirstOrDefault(x => x.id_marca == id);
            return View(m);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                marca m = new marca();
                m = db.marca.FirstOrDefault(x => x.id_marca == id);
                m.nombre = collection["nombre"];
                m.estado = collection["estado"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            marca m = db.marca.FirstOrDefault(x => x.id_marca == id);
            return View(m);
        }

        // POST: Marca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                marca m = db.marca.FirstOrDefault(x => x.id_marca == id);
                db.marca.Remove(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
