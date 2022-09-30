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
    public class Examen_medicoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Examen_medico
        public ActionResult Index2()
        {
            var examen_medico = db.Examen_medico.Include(e => e.Diagnostico);
            return View(examen_medico.ToList());
        }

        // GET: Examen_medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_medico examen_medico = db.Examen_medico.Find(id);
            if (examen_medico == null)
            {
                return HttpNotFound();
            }
            return View(examen_medico);
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

        // GET: Examen_medico/Create
        public ActionResult Create()
        {
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre");
            return View();
        }

        // POST: Examen_medico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idExamen_medico,estado,fecha_encargo,nombre,area,encargado,fecha_resultado,resultado,idDiagnostico")] Examen_medico examen_medico)
        {
            if (ModelState.IsValid)
            {
                db.Examen_medico.Add(examen_medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", examen_medico.idDiagnostico);
            return View(examen_medico);
        }

        // GET: Examen_medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_medico examen_medico = db.Examen_medico.Find(id);
            if (examen_medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", examen_medico.idDiagnostico);
            return View(examen_medico);
        }

        // POST: Examen_medico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExamen_medico,estado,fecha_encargo,nombre,area,encargado,fecha_resultado,resultado,idDiagnostico")] Examen_medico examen_medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen_medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", examen_medico.idDiagnostico);
            return View(examen_medico);
        }

        // GET: Examen_medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen_medico examen_medico = db.Examen_medico.Find(id);
            if (examen_medico == null)
            {
                return HttpNotFound();
            }
            return View(examen_medico);
        }

        // POST: Examen_medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examen_medico examen_medico = db.Examen_medico.Find(id);
            db.Examen_medico.Remove(examen_medico);
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
