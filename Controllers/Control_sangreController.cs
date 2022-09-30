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
    public class Control_sangreController : Controller
    {
        private Model1 db = new Model1();

        // GET: Control_sangre
        public ActionResult Index2()
        {
            var control_sangre = db.Control_sangre.Include(c => c.Diagnostico);
            return View(control_sangre.ToList());
        }

        // GET: Control_sangre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control_sangre control_sangre = db.Control_sangre.Find(id);
            if (control_sangre == null)
            {
                return HttpNotFound();
            }
            return View(control_sangre);
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


        // GET: Control_sangre/Create
        public ActionResult Create()
        {
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre");
            return View();
        }

        // POST: Control_sangre/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idControl_sangre,leucocitos,EMR,hemoglobina,plaquetas,linfoblasto,neutrofilos,idDiagnostico")] Control_sangre control_sangre)
        {
            if (ModelState.IsValid)
            {
                db.Control_sangre.Add(control_sangre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", control_sangre.idDiagnostico);
            return View(control_sangre);
        }

        // GET: Control_sangre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control_sangre control_sangre = db.Control_sangre.Find(id);
            if (control_sangre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", control_sangre.idDiagnostico);
            return View(control_sangre);
        }

        // POST: Control_sangre/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idControl_sangre,leucocitos,EMR,hemoglobina,plaquetas,linfoblasto,neutrofilos,idDiagnostico")] Control_sangre control_sangre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(control_sangre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDiagnostico = new SelectList(db.Diagnostico, "idDiagnostico", "nombre", control_sangre.idDiagnostico);
            return View(control_sangre);
        }

        // GET: Control_sangre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control_sangre control_sangre = db.Control_sangre.Find(id);
            if (control_sangre == null)
            {
                return HttpNotFound();
            }
            return View(control_sangre);
        }

        // POST: Control_sangre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Control_sangre control_sangre = db.Control_sangre.Find(id);
            db.Control_sangre.Remove(control_sangre);
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
