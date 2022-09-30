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
    public class Tratamiento_previoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tratamiento_previo
        public ActionResult Index2()
        {
            var tratamiento_previo = db.Tratamiento_previo.Include(t => t.Condicion_previa);
            return View(tratamiento_previo.ToList());
        }

        // GET: Tratamiento_previo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_previo tratamiento_previo = db.Tratamiento_previo.Find(id);
            if (tratamiento_previo == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento_previo);
        }
        public ActionResult Index()
        {
            return View(db.Paciente.ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }
        // GET: Tratamiento_previo/Create
        public ActionResult Create()
        {
            ViewBag.idCondicion_previa = new SelectList(db.Condicion_previa, "idCondicion_previa", "antecedente_familiar");
            return View();
        }

        // POST: Tratamiento_previo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTratamiento_previo,nombre,grado,grado_elev,fecha_inicio,fecha_fin,idCondicion_previa")] Tratamiento_previo tratamiento_previo)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento_previo.Add(tratamiento_previo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCondicion_previa = new SelectList(db.Condicion_previa, "idCondicion_previa", "antecedente_familiar", tratamiento_previo.idCondicion_previa);
            return View(tratamiento_previo);
        }

        // GET: Tratamiento_previo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_previo tratamiento_previo = db.Tratamiento_previo.Find(id);
            if (tratamiento_previo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCondicion_previa = new SelectList(db.Condicion_previa, "idCondicion_previa", "antecedente_familiar", tratamiento_previo.idCondicion_previa);
            return View(tratamiento_previo);
        }

        // POST: Tratamiento_previo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTratamiento_previo,nombre,grado,grado_elev,fecha_inicio,fecha_fin,idCondicion_previa")] Tratamiento_previo tratamiento_previo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento_previo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCondicion_previa = new SelectList(db.Condicion_previa, "idCondicion_previa", "antecedente_familiar", tratamiento_previo.idCondicion_previa);
            return View(tratamiento_previo);
        }

        // GET: Tratamiento_previo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_previo tratamiento_previo = db.Tratamiento_previo.Find(id);
            if (tratamiento_previo == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento_previo);
        }

        // POST: Tratamiento_previo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento_previo tratamiento_previo = db.Tratamiento_previo.Find(id);
            db.Tratamiento_previo.Remove(tratamiento_previo);
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
