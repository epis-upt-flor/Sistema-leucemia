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
    public class TratamientoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tratamiento
        public ActionResult Index2()
        {
            var tratamiento = db.Tratamiento.Include(t => t.Diagnostico);
            return View(tratamiento.ToList());
        }
        // GET: Paciente
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
        // GET: Tratamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }
        // GET: Tratamiento/Details2/5
        public ActionResult VerTratamiento(int? id)
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

        // GET: Tratamiento/Create
        public ActionResult Create()
        {
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre");
            return View();
        }

        // POST: Tratamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTratamiento,etapa,protocolo,fecha_inicio,fecha_fin,observacion,idDiagnostico")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", tratamiento.idDiagnostico);
            return View(tratamiento);
        }

        // GET: Tratamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", tratamiento.idDiagnostico);
            return View(tratamiento);
        }

        // POST: Tratamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTratamiento,etapa,protocolo,fecha_inicio,fecha_fin,observacion,idDiagnostico")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", tratamiento.idDiagnostico);
            return View(tratamiento);
        }

        // GET: Tratamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            db.Tratamiento.Remove(tratamiento);
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
