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
    public class DiagnosticoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Paciente
        public ActionResult Index()
        {
            return View(db.Paciente.ToList());
        }
        // GET: Paciente
        public ActionResult DiagPaciente()
        {
            return View(db.Diagnostico.ToList());
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

        // GET: Diagnostico
        public ActionResult Index2()
        {
            var diagnostico = db.Diagnostico.Include(d => d.Paciente).Include(d => d.Personal);
            return View(diagnostico.ToList());
        }

        // GET: Diagnostico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // GET: Diagnostico/Create
        public ActionResult Create()
        {
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni");
            ViewBag.idPersonal = new SelectList(db.Personal, "idPersonal", "dni");
            return View();
        }

        // POST: Diagnostico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDiagnostico,nombre,condicion,observacion,idPersonal,idPaciente")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Diagnostico.Add(diagnostico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni", diagnostico.idPaciente);
            ViewBag.idPersonal = new SelectList(db.Personal, "idPersonal", "dni", diagnostico.idPersonal);
            return View(diagnostico);
        }

        // GET: Diagnostico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni", diagnostico.idPaciente);
            ViewBag.idPersonal = new SelectList(db.Personal, "idPersonal", "dni", diagnostico.idPersonal);
            return View(diagnostico);
        }

        // POST: Diagnostico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDiagnostico,nombre,condicion,observacion,idPersonal,idPaciente")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnostico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni", diagnostico.idPaciente);
            ViewBag.idPersonal = new SelectList(db.Personal, "idPersonal", "dni", diagnostico.idPersonal);
            return View(diagnostico);
        }

        // GET: Diagnostico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // POST: Diagnostico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            db.Diagnostico.Remove(diagnostico);
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
