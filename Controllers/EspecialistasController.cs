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
    public class EspecialistasController : Controller
    {
        private NaturalAge db = new NaturalAge();

        // GET: Especialistas
        public ActionResult Index()
        {
            return View(db.Especialista.ToList());
        }

        // GET: Especialistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialista especialista = db.Especialista.Find(id);
            if (especialista == null)
            {
                return HttpNotFound();
            }
            return View(especialista);
        }

        // GET: Especialistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EspecialistaID,Nombre_Especialista,Apellido_Especialista,Cedula,Telefono,Especialidad")] Especialista especialista)
        {
            if (ModelState.IsValid)
            {
                db.Especialista.Add(especialista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialista);
        }

        // GET: Especialistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialista especialista = db.Especialista.Find(id);
            if (especialista == null)
            {
                return HttpNotFound();
            }
            return View(especialista);
        }

        // POST: Especialistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EspecialistaID,Nombre_Especialista,Apellido_Especialista,Cedula,Telefono,Especialidad")] Especialista especialista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialista);
        }

        // GET: Especialistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialista especialista = db.Especialista.Find(id);
            if (especialista == null)
            {
                return HttpNotFound();
            }
            return View(especialista);
        }

        // POST: Especialistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialista especialista = db.Especialista.Find(id);
            db.Especialista.Remove(especialista);
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
