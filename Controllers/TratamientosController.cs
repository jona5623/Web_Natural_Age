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
    public class TratamientosController : Controller
    {
        private NaturalAge db = new NaturalAge();

        // GET: Tratamientos
        public ActionResult Index()
        {
            var tratamiento = db.Tratamiento.Include(t => t.Cita);
            return View(tratamiento.ToList());
        }

        // GET: Tratamientos/Details/5
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

        // GET: Tratamientos/Create
        public ActionResult Create()
        {
            ViewBag.CitaID = new SelectList(db.Cita, "CitaID", "CitaID");
            return View();
        }

        // POST: Tratamientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TratamientoID,CitaID,Tipo,Descripcion")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CitaID = new SelectList(db.Cita, "CitaID", "CitaID", tratamiento.CitaID);
            return View(tratamiento);
        }

        // GET: Tratamientos/Edit/5
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
            ViewBag.CitaID = new SelectList(db.Cita, "CitaID", "CitaID", tratamiento.CitaID);
            return View(tratamiento);
        }

        // POST: Tratamientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TratamientoID,CitaID,Tipo,Descripcion")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CitaID = new SelectList(db.Cita, "CitaID", "CitaID", tratamiento.CitaID);
            return View(tratamiento);
        }

        // GET: Tratamientos/Delete/5
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

        // POST: Tratamientos/Delete/5
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
