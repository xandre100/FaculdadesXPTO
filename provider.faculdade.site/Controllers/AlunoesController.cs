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
    public class AlunoesController : Controller
    {
        private AlunoRepositorio repositorio = new AlunoRepositorio();

        // GET: Alunoes
        public ActionResult Index()
        {
            return View(repositorio.obterTodos().OrderBy(a => a.Matricula));
        }

        // GET: Alunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matricula,Nome,CPF")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (!Helpers.Utils.ValidarCPF(aluno.CPF))
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "O CPF FOI INFORMADO INCORRETAMENTE");

                repositorio.criar(aluno);
                repositorio.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matricula,Nome,CPF")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (!Helpers.Utils.ValidarCPF(aluno.CPF))
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "O CPF FOI INFORMADO INCORRETAMENTE");

                repositorio.atualizar(aluno);
                repositorio.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorio.excluir(a => a.Matricula == id);
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
