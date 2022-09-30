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
    public class Tsugerido_MedicamentoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tsugerido_Medicamento
        public ActionResult Index()
        {
            var tsugerido_Medicamento = db.Tsugerido_Medicamento.Include(t => t.Tratamiento_sugerido);
            return View(tsugerido_Medicamento.ToList());
        }

        // GET: Tsugerido_Medicamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tsugerido_Medicamento tsugerido_Medicamento = db.Tsugerido_Medicamento.Find(id);
            if (tsugerido_Medicamento == null)
            {
                return HttpNotFound();
            }
            return View(tsugerido_Medicamento);
        }

        // GET: Tsugerido_Medicamento/Create
        public ActionResult Create()
        {
            ViewBag.idTsugerido = new SelectList(db.Tratamiento_sugerido, "idTratamiento_sugerido", "duracion");
            return View();
        }

        // POST: Tsugerido_Medicamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTsugerido_Medicamento,codigo_med,cantidad,medida,recurrencia,fecha_inicio,fecha_fin,idTsugerido")] Tsugerido_Medicamento tsugerido_Medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Tsugerido_Medicamento.Add(tsugerido_Medicamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTsugerido = new SelectList(db.Tratamiento_sugerido, "idTratamiento_sugerido", "duracion", tsugerido_Medicamento.idTsugerido);
            return View(tsugerido_Medicamento);
        }

        // GET: Tsugerido_Medicamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tsugerido_Medicamento tsugerido_Medicamento = db.Tsugerido_Medicamento.Find(id);
            if (tsugerido_Medicamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTsugerido = new SelectList(db.Tratamiento_sugerido, "idTratamiento_sugerido", "duracion", tsugerido_Medicamento.idTsugerido);
            return View(tsugerido_Medicamento);
        }

        // POST: Tsugerido_Medicamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTsugerido_Medicamento,codigo_med,cantidad,medida,recurrencia,fecha_inicio,fecha_fin,idTsugerido")] Tsugerido_Medicamento tsugerido_Medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tsugerido_Medicamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTsugerido = new SelectList(db.Tratamiento_sugerido, "idTratamiento_sugerido", "duracion", tsugerido_Medicamento.idTsugerido);
            return View(tsugerido_Medicamento);
        }

        // GET: Tsugerido_Medicamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tsugerido_Medicamento tsugerido_Medicamento = db.Tsugerido_Medicamento.Find(id);
            if (tsugerido_Medicamento == null)
            {
                return HttpNotFound();
            }
            return View(tsugerido_Medicamento);
        }

        // POST: Tsugerido_Medicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tsugerido_Medicamento tsugerido_Medicamento = db.Tsugerido_Medicamento.Find(id);
            db.Tsugerido_Medicamento.Remove(tsugerido_Medicamento);
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
