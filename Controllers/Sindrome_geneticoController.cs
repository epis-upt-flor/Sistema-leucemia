using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Leucemia_v2.Models;

namespace Sistema_Leucemia_v2.Controllers
{
    public class Sindrome_geneticoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sindrome_genetico
        public ActionResult Index()
        {
            return View(db.Sindrome_genetico.ToList());
        }

        // GET: Sindrome_genetico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sindrome_genetico sindrome_genetico = db.Sindrome_genetico.Find(id);
            if (sindrome_genetico == null)
            {
                return HttpNotFound();
            }
            return View(sindrome_genetico);
        }

        // GET: Sindrome_genetico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sindrome_genetico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSindrome_genetico,nombre,grado")] Sindrome_genetico sindrome_genetico)
        {
            if (ModelState.IsValid)
            {
                db.Sindrome_genetico.Add(sindrome_genetico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sindrome_genetico);
        }

        // GET: Sindrome_genetico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sindrome_genetico sindrome_genetico = db.Sindrome_genetico.Find(id);
            if (sindrome_genetico == null)
            {
                return HttpNotFound();
            }
            return View(sindrome_genetico);
        }

        // POST: Sindrome_genetico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSindrome_genetico,nombre,grado")] Sindrome_genetico sindrome_genetico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sindrome_genetico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sindrome_genetico);
        }

        // GET: Sindrome_genetico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sindrome_genetico sindrome_genetico = db.Sindrome_genetico.Find(id);
            if (sindrome_genetico == null)
            {
                return HttpNotFound();
            }
            return View(sindrome_genetico);
        }

        // POST: Sindrome_genetico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sindrome_genetico sindrome_genetico = db.Sindrome_genetico.Find(id);
            db.Sindrome_genetico.Remove(sindrome_genetico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
