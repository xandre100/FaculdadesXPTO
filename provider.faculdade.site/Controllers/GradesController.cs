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
    public class GradesController : Controller
    {
        private GradeRepositorio gradeRepo = new GradeRepositorio();
        private AlunoRepositorio alunoRep = new AlunoRepositorio();
        private DisciplinaRepositorio disciplinaRepo = new DisciplinaRepositorio();
        private SemestreRepositorio semestreRepo = new SemestreRepositorio();
        private TurmaRepositorio turmaRepo = new TurmaRepositorio();


        public GradesController()
        {

        }

        // GET: Grades
        public ActionResult Index()
        {
            var grades = gradeRepo.obterTodos();
            return View(grades.ToList());
        }

        // GET: Grades/Details/5
        public ActionResult Details(int idDisciplina, int idSemestre, int idTurma, int matricula)
        {

            Grade grade = gradeRepo.buscar(g => g.IdDisciplina == idDisciplina
                                                    && g.IdSemestre == idSemestre
                                                    && g.IdTurma == idTurma
                                                    && g.Matricula == matricula).FirstOrDefault();
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // GET: Grades/Create
        public ActionResult Create()
        {
            ViewBag.IdDisciplina = new SelectList(disciplinaRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdSemestre = new SelectList(semestreRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdTurma = new SelectList(turmaRepo.obterTodos(), "Id", "Turma1");
            ViewBag.Matricula = new SelectList(alunoRep.obterTodos().OrderBy(a => a.Matricula), "Matricula", "Nome");
            return View();
        }


        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDisciplina,IdSemestre,IdTurma,Matricula")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                Grade gradeExiste = gradeRepo.buscar(g => g.IdDisciplina == grade.IdDisciplina
                                                        && g.IdSemestre == grade.IdSemestre
                                                        && g.IdTurma == grade.IdTurma
                                                        && g.Matricula == grade.Matricula).FirstOrDefault();

                if(gradeExiste != null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "O ALUNO INFORMADO JÁ POSSUI ESTA GRADE CADASTRADA.");

                gradeRepo.criar(grade);
                gradeRepo.SalvarTodos();
                return RedirectToAction("Index");
            }

            ViewBag.IdDisciplina = new SelectList(disciplinaRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdSemestre = new SelectList(semestreRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdTurma = new SelectList(turmaRepo.obterTodos(), "Id", "Turma1");
            ViewBag.Matricula = new SelectList(alunoRep.obterTodos().OrderBy(a => a.Matricula), "Matricula", "Nome");
            return View(grade);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int idDisciplina, int idSemestre, int idTurma, int matricula)
        {

            Grade grade = gradeRepo.buscar(g => g.IdDisciplina == idDisciplina
                                                    && g.IdSemestre == idSemestre
                                                    && g.IdTurma == idTurma
                                                    && g.Matricula == matricula).FirstOrDefault();
            if (grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDisciplina = new SelectList(disciplinaRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdSemestre = new SelectList(semestreRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdTurma = new SelectList(turmaRepo.obterTodos(), "Id", "Turma1");
            ViewBag.Matricula = new SelectList(alunoRep.obterTodos().OrderBy(a => a.Matricula), "Matricula", "Nome");

            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDisciplina,IdSemestre,IdTurma,Matricula")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                gradeRepo.atualizar(grade);
                gradeRepo.SalvarTodos();
                return RedirectToAction("Index");
            }
            ViewBag.IdDisciplina = new SelectList(disciplinaRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdSemestre = new SelectList(semestreRepo.obterTodos(), "Id", "Descricao");
            ViewBag.IdTurma = new SelectList(turmaRepo.obterTodos(), "Id", "Turma1");
            ViewBag.Matricula = new SelectList(alunoRep.obterTodos().OrderBy(a => a.Matricula), "Matricula", "Nome");

            return View(grade);
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int idDisciplina, int idSemestre, int idTurma, int matricula)
        {

            Grade grade = gradeRepo.buscar(g => g.IdDisciplina == idDisciplina
                                                    && g.IdSemestre == idSemestre
                                                    && g.IdTurma == idTurma
                                                    && g.Matricula == matricula).FirstOrDefault();
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idDisciplina, int idSemestre, int idTurma, int matricula)
        {

            gradeRepo.excluir(g => g.IdDisciplina == idDisciplina
                                                    && g.IdSemestre == idSemestre
                                                    && g.IdTurma == idTurma
                                                    && g.Matricula == matricula);
            gradeRepo.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                gradeRepo.Dispose();
                alunoRep.Dispose();
                disciplinaRepo.Dispose();
                semestreRepo.Dispose();
                turmaRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
