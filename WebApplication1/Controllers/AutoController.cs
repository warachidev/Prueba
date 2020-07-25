using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        BDAutosEntities db = new BDAutosEntities();
        public ActionResult Index()
        {
            var lista = db.autos.ToList();
            return View(lista);
        }

        // GET: Auto/Details/5
        public ActionResult Details(int id)
        {
            autos a = db.autos.FirstOrDefault(x => x.id_auto == id);
            return View(a);
        }

        public List<SelectListItem>ObtenerListado() {
            var listaEstado = new List<SelectListItem>() {
                        new SelectListItem(){ Text = "ACTIVO",Value = "ACTIVO"},
                        new SelectListItem(){ Text = "INACTIVO",Value = "INACTIVO"}
                    };
            return listaEstado;
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            var obj = new autos();
            List<marca> listamarca = new List<marca>();
            listamarca = db.marca.ToList();
            List<SelectListItem> var = new List<SelectListItem>();
            foreach (var item in listamarca)
            {
                var.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.id_marca.ToString()
                });
            }
            ViewBag.MisMarcas = var;
            ViewBag.MiListado = ObtenerListado();  
            return View();
        }

        // POST: Auto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                autos a = new autos();
                a.placa = collection["placa"].ToString();
                a.modelo = collection["modelo"].ToString();
                a.id_marca = int.Parse(collection["id_marca"].ToString());
                a.cc = int.Parse(collection["cc"].ToString());
                a.color = collection["color"].ToString();
                a.fechafab = DateTime.Parse(collection["fechafab"].ToString());
                a.estado = collection["estado"].ToString();
                db.autos.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(int id)
        {
            autos a = db.autos.FirstOrDefault(x => x.id_auto == id);
            return View(a);
        }

        // POST: Auto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                autos a = new autos();
                a = db.autos.FirstOrDefault(x => x.id_auto == id);
                a.placa = collection["placa"].ToString();
                a.modelo = collection["modelo"].ToString();
                a.id_marca = int.Parse(collection["id_marca"].ToString());
                a.cc = int.Parse(collection["cc"].ToString());
                a.color = collection["color"].ToString();
                a.fechafab = DateTime.Parse(collection["fechafab"].ToString());
                a.estado = collection["estado"].ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(int id)
        {
            autos a = db.autos.FirstOrDefault(x => x.id_auto == id);
            return View(a);
        }

        // POST: Auto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                autos a = db.autos.FirstOrDefault(x => x.id_auto == id);
                db.autos.Remove(a);
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
