using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZoologicoSite;

namespace ZoologicoSite.Controllers
{
    public class ContinenteController : Controller
    {
        private ZOOSEntities dbContext = new ZOOSEntities();

        // GET: Continente
        public ActionResult Index()
        {
            var continentes = (from c in dbContext.T_Continente select c).ToList();
            return View(continentes);
        }

        // GET: Continente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var t_Continente = dbContext.T_Continente.Find(id);
            if (t_Continente == null)
            {
                return HttpNotFound();
            }
            return View(t_Continente);
        }

        // GET: Continente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Continente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre_Continente")] T_Continente t_Continente)
        {
            if (ModelState.IsValid)
            {
                dbContext.T_Continente.Add(t_Continente);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Continente);
        }

        // GET: Continente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var t_Continente = dbContext.T_Continente.Find(id);
            if (t_Continente == null)
            {
                return HttpNotFound();
            }
            return View(t_Continente);
        }

        // POST: Continente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre_Continente")] T_Continente t_Continente)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(t_Continente).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Continente);
        }

        // GET: Continente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Continente t_Continente = dbContext.T_Continente.Find(id);
            if (t_Continente == null)
            {
                return HttpNotFound();
            }
            return View(t_Continente);
        }

        // POST: Continente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var t_Continente = dbContext.T_Continente.Find(id);
            dbContext.T_Continente.Remove(t_Continente);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AyudaContinente()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
