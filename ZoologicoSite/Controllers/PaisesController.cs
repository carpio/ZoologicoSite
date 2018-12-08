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
        //public ActionResult Index()
        //{
        //    //var paises = (from p in dbContext.T_Pais
        //    //              where p.ID_Continente == 1
        //    //              select p
        //    //              ).ToList();
        //    //var paises2 = dbContext.T_Pais.Where(p => p.ID_Continente == 1).ToList();
        //    var modelo = new ContinentesPaisesModel();
        //    modelo.ListaContinentes = (from c in dbContext.T_Continente select c).ToList();
        //    modelo.ListaPaises = dbContext.T_Pais.ToList();
        //    return View(modelo);
        //}

        public ActionResult Index(string nombreContinente)
        {
            var modelo = new ContinentesPaisesModel();
            var continenteList = (from c in dbContext.T_Continente select c).ToList();
            var selectList = new List<SelectListItem>();

            //All option
            var allOption = new SelectListItem();
            allOption.Value = "All";
            allOption.Text = "All";
            selectList.Add(allOption);

            if (string.IsNullOrEmpty(nombreContinente))
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
            //var modelo = new ContinentesPaisesModel();

            //if (id == null)
            //{
            //    modelo.ListaContinentes = (from c in dbContext.T_Continente select c).ToList();
            //    modelo.ListaPaises = dbContext.T_Pais.ToList();
            //    return View(modelo);
            //}
            //else
            //{
            //var continenteList = (from c in dbContext.T_Continente select c).ToList();
            //var selectList = new List<SelectListItem>();
            //foreach(var c in continenteList)
            //{
            //    var selectItem = new SelectListItem();
            //    selectItem.Value = c.Nombre_Continente;
            //    selectItem.Text = c.Nombre_Continente;
            //    selectList.Add(selectItem);
            //}
            //modelo.ListaContinentes = selectList;
            //modelo.ListaPaises = (from p in dbContext.T_Pais where p.T_Continente.Nombre_Continente == nombreContinente select p).ToList();
            //return View(modelo);
            //}
        }
        
        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, Nombre_Pais, ID_Continente")] T_Pais pais)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    dbContext.T_Pais.Add(pais);
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
