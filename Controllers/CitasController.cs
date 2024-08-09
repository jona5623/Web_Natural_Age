using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Natural_Age.Models;

namespace Natural_Age.Controllers
{
    public class CitasController : Controller
    {
        private NaturalAge db = new NaturalAge();

        // GET: Citas
        public ActionResult Index()
        {
            var cita = db.Cita.Include(c => c.Especialista).Include(c => c.Paciente);
            return View(cita.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.EspecialistaID = new SelectList(db.Especialista, "EspecialistaID", "Nombre_Especialista");
            ViewBag.PacienteID = new SelectList(db.Paciente, "PacienteID", "Nombre_Paciente");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CitaID,PacienteID,EspecialistaID,Fecha")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialistaID = new SelectList(db.Especialista, "EspecialistaID", "Nombre_Especialista", cita.EspecialistaID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "PacienteID", "Nombre_Paciente", cita.PacienteID);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialistaID = new SelectList(db.Especialista, "EspecialistaID", "Nombre_Especialista", cita.EspecialistaID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "PacienteID", "Nombre_Paciente", cita.PacienteID);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CitaID,PacienteID,EspecialistaID,Fecha")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialistaID = new SelectList(db.Especialista, "EspecialistaID", "Nombre_Especialista", cita.EspecialistaID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "PacienteID", "Nombre_Paciente", cita.PacienteID);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
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
