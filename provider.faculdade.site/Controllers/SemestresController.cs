using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using provider.faculdade.model;

namespace provider.faculdade.site.Controllers
{
    public class SemestresController : Controller
    {
        private FaculdadesDBEntities db = new FaculdadesDBEntities();

        // GET: Semestres
        public ActionResult Index()
        {
            return View(db.Semestres.ToList());
        }

        // GET: Semestres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestres.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // GET: Semestres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semestres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                db.Semestres.Add(semestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semestre);
        }

        // GET: Semestres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestres.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // POST: Semestres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semestre);
        }

        // GET: Semestres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestres.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // POST: Semestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semestre semestre = db.Semestres.Find(id);
            db.Semestres.Remove(semestre);
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
