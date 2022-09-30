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
    public class Tratamiento_medicamentoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tratamiento_medicamento
        public ActionResult Index()
        {
            var tratamiento_medicamento = db.Tratamiento_medicamento.Include(t => t.Medicamento).Include(t => t.Tratamiento);
            return View(tratamiento_medicamento.ToList());
        }

        // GET: Tratamiento_medicamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_medicamento tratamiento_medicamento = db.Tratamiento_medicamento.Find(id);
            if (tratamiento_medicamento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento_medicamento);
        }

        // GET: Tratamiento_medicamento/Create
        public ActionResult Create()
        {
            ViewBag.idMedicamento = new SelectList(db.Medicamento, "idMedicamento", "nombre");
            ViewBag.idTratamiento = new SelectList(db.Tratamiento, "idTratamiento", "etapa");
            return View();
        }

        // POST: Tratamiento_medicamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTratamiento,idMedicamento,cantidad,medida,recurrencia,fecha_inicio,fecha_fin")] Tratamiento_medicamento tratamiento_medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento_medicamento.Add(tratamiento_medicamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMedicamento = new SelectList(db.Medicamento, "idMedicamento", "nombre", tratamiento_medicamento.idMedicamento);
            ViewBag.idTratamiento = new SelectList(db.Tratamiento, "idTratamiento", "etapa", tratamiento_medicamento.idTratamiento);
            return View(tratamiento_medicamento);
        }

        // GET: Tratamiento_medicamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_medicamento tratamiento_medicamento = db.Tratamiento_medicamento.Find(id);
            if (tratamiento_medicamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedicamento = new SelectList(db.Medicamento, "idMedicamento", "nombre", tratamiento_medicamento.idMedicamento);
            ViewBag.idTratamiento = new SelectList(db.Tratamiento, "idTratamiento", "etapa", tratamiento_medicamento.idTratamiento);
            return View(tratamiento_medicamento);
        }

        // POST: Tratamiento_medicamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTratamiento,idMedicamento,cantidad,medida,recurrencia,fecha_inicio,fecha_fin")] Tratamiento_medicamento tratamiento_medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento_medicamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMedicamento = new SelectList(db.Medicamento, "idMedicamento", "nombre", tratamiento_medicamento.idMedicamento);
            ViewBag.idTratamiento = new SelectList(db.Tratamiento, "idTratamiento", "etapa", tratamiento_medicamento.idTratamiento);
            return View(tratamiento_medicamento);
        }

        // GET: Tratamiento_medicamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento_medicamento tratamiento_medicamento = db.Tratamiento_medicamento.Find(id);
            if (tratamiento_medicamento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento_medicamento);
        }

        // POST: Tratamiento_medicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento_medicamento tratamiento_medicamento = db.Tratamiento_medicamento.Find(id);
            db.Tratamiento_medicamento.Remove(tratamiento_medicamento);
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
