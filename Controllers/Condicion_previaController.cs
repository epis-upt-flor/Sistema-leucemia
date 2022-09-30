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
    public class Condicion_previaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Condicion_previa
        public ActionResult Index2()
        {
            var condicion_previa = db.Condicion_previa.Include(c => c.Paciente);
            return View(condicion_previa.ToList());
        }

        // GET: Condicion_previa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion_previa condicion_previa = db.Condicion_previa.Find(id);
            if (condicion_previa == null)
            {
                return HttpNotFound();
            }
            return View(condicion_previa);
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
        // GET: Condicion_previa/Create
        public ActionResult Create()
        {
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni");
            return View();
        }

        // POST: Condicion_previa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCondicion_previa,antecedente_familiar,radiacion,tabaquismo,sustancia_quimica,idPaciente")] Condicion_previa condicion_previa)
        {
            if (ModelState.IsValid)
            {
                db.Condicion_previa.Add(condicion_previa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni", condicion_previa.idPaciente);
            return View(condicion_previa);
        }

        // GET: Condicion_previa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion_previa condicion_previa = db.Condicion_previa.Find(id);
            if (condicion_previa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni", condicion_previa.idPaciente);
            return View(condicion_previa);
        }

        // POST: Condicion_previa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCondicion_previa,antecedente_familiar,radiacion,tabaquismo,sustancia_quimica,idPaciente")] Condicion_previa condicion_previa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicion_previa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPaciente = new SelectList(db.Paciente, "idPaciente", "dni", condicion_previa.idPaciente);
            return View(condicion_previa);
        }

        // GET: Condicion_previa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion_previa condicion_previa = db.Condicion_previa.Find(id);
            if (condicion_previa == null)
            {
                return HttpNotFound();
            }
            return View(condicion_previa);
        }

        // POST: Condicion_previa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condicion_previa condicion_previa = db.Condicion_previa.Find(id);
            db.Condicion_previa.Remove(condicion_previa);
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
