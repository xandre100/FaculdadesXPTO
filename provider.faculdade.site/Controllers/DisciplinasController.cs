using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using provider.faculdade.model;
using provider.faculdade.model.repositorio;

namespace provider.faculdade.site.Controllers
{
    public class DisciplinasController : Controller
    {
        private DisciplinaRepositorio repositorio = new DisciplinaRepositorio();

        // GET: Disciplinas
        public ActionResult Index()
        {
            return View(repositorio.obterTodos().OrderBy(d => d.Descricao));
        }

        // GET: Disciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = repositorio.buscar(d => d.Id == id).FirstOrDefault();
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                repositorio.criar(disciplina);
                repositorio.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = repositorio.buscar(d => d.Id == id).FirstOrDefault();
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                repositorio.atualizar(disciplina);
                repositorio.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = repositorio.buscar(d => d.Id == id).FirstOrDefault();
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorio.excluir(d => d.Id == id);
            repositorio.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repositorio.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
