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
    public class SintomaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Sintoma
        public ActionResult Index()
        {
            return View(db.Sintoma.ToList());
        }

        // GET: Sintoma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sintoma sintoma = db.Sintoma.Find(id);
            if (sintoma == null)
            {
                return HttpNotFound();
            }
            return View(sintoma);
        }

        // GET: Sintoma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sintoma/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSintoma,nombre,tipo,descripcion,estado")] Sintoma sintoma)
        {
            if (ModelState.IsValid)
            {
                db.Sintoma.Add(sintoma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sintoma);
        }

        // GET: Sintoma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sintoma sintoma = db.Sintoma.Find(id);
            if (sintoma == null)
            {
                return HttpNotFound();
            }
            return View(sintoma);
        }

        // POST: Sintoma/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSintoma,nombre,tipo,descripcion,estado")] Sintoma sintoma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sintoma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sintoma);
        }

        // GET: Sintoma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sintoma sintoma = db.Sintoma.Find(id);
            if (sintoma == null)
            {
                return HttpNotFound();
            }
            return View(sintoma);
        }

        // POST: Sintoma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sintoma sintoma = db.Sintoma.Find(id);
            db.Sintoma.Remove(sintoma);
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
