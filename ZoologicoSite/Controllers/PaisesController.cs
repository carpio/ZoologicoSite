using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoologicoSite.Models;

namespace ZoologicoSite.Controllers
{
    public class PaisesController : Controller
    {
        private ZOOSEntities dbContext = new ZOOSEntities();
        // GET: Paises
        
        public ActionResult Index(string nombreContinente)
        {
            var modelo = new ContinentesPaisesModel();
            var continenteList = (from c in dbContext.T_Continente select c).ToList();
            var selectList = new List<SelectListItem>();

            //All option
            var allOption = new SelectListItem();
            allOption.Value = "Todos";
            allOption.Text = "Todos";
            selectList.Add(allOption);

            if (string.IsNullOrEmpty(nombreContinente) || nombreContinente == "Todos")
            {                
                foreach (var c in continenteList)
                {
                    var selectItem = new SelectListItem();
                    selectItem.Value = c.Nombre_Continente;
                    selectItem.Text = c.Nombre_Continente;
                    selectList.Add(selectItem);
                }
                modelo.ListaContinentes = selectList;
                modelo.ListaPaises = (from p in dbContext.T_Pais select p).ToList();
                return View(modelo);
            }
            else
            {       
                
                foreach (var c in continenteList)
                {
                    var selectItem = new SelectListItem();
                    selectItem.Value = c.Nombre_Continente;
                    selectItem.Text = c.Nombre_Continente;
                    selectList.Add(selectItem);
                }
                modelo.ListaContinentes = selectList;
                modelo.ListaPaises = (from p in dbContext.T_Pais where p.T_Continente.Nombre_Continente == nombreContinente select p).ToList();
                return View(modelo);
            }
            
        }
        
        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            var modelo = new ContinentesPaisesModel();

            var selectList = new List<SelectListItem>();

            var continenteList = dbContext.T_Continente.Select(s => new {
                s.ID,
                s.Nombre_Continente
            }).ToList();

            foreach (var c in continenteList)
            {
                var selectItem = new SelectListItem();
                selectItem.Value = c.Nombre_Continente;
                selectItem.Text = c.Nombre_Continente;
                selectList.Add(selectItem);
            }
            modelo.ListaContinentes = selectList;        
            
            return View(modelo);
        }

        // POST: Paises/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, NombrePais, NombreContinente")] ContinentesPaisesModel pais)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    var nuevoPais = new T_Pais();

                    var continente = (from c in dbContext.T_Continente
                                      where c.Nombre_Continente == pais.NombreContinente
                                      select c).FirstOrDefault();
                    //var continente2 = dbContext.T_Continente.FirstOrDefault(s => s.Nombre_Continente == pais.NombreContinente);

                    nuevoPais.ID_Continente = continente.ID;
                    nuevoPais.Nombre_Pais = pais.NombrePais;

                    dbContext.T_Pais.Add(nuevoPais);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paises/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paises/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
