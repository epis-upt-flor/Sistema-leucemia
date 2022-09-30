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
    public class Tratamiento_sugeridoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tratamiento_sugerido
        public ActionResult Index()
        {
            var tratamiento_sugerido = db.Tratamiento_sugerido.Include(t => t.Diagnostico);
            return View(tratamiento_sugerido.ToList());
        }

        // GET: Tratamiento_sugerido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_sugerido tratamiento_sugerido = db.Tratamiento_sugerido.Find(id);
            if (tratamiento_sugerido == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento_sugerido);
        }

        // GET: Tratamiento_sugerido/Create
        public ActionResult Create()
        {
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre");
            return View();
        }

        // POST: Tratamiento_sugerido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTratamiento_sugerido,duracion,protocolo,idDiagnostico")] Tratamiento_sugerido tratamiento_sugerido)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento_sugerido.Add(tratamiento_sugerido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", tratamiento_sugerido.idDiagnostico);
            return View(tratamiento_sugerido);
        }

        // GET: Tratamiento_sugerido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_sugerido tratamiento_sugerido = db.Tratamiento_sugerido.Find(id);
            if (tratamiento_sugerido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", tratamiento_sugerido.idDiagnostico);
            return View(tratamiento_sugerido);
        }

        // POST: Tratamiento_sugerido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTratamiento_sugerido,duracion,protocolo,idDiagnostico")] Tratamiento_sugerido tratamiento_sugerido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento_sugerido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", tratamiento_sugerido.idDiagnostico);
            return View(tratamiento_sugerido);
        }

        // GET: Tratamiento_sugerido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_sugerido tratamiento_sugerido = db.Tratamiento_sugerido.Find(id);
            if (tratamiento_sugerido == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento_sugerido);
        }

        // POST: Tratamiento_sugerido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento_sugerido tratamiento_sugerido = db.Tratamiento_sugerido.Find(id);
            db.Tratamiento_sugerido.Remove(tratamiento_sugerido);
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
