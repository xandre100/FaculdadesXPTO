using provider.faculdade.model;
using provider.faculdade.model.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace provider.faculdade.site.Controllers
{
    public class AlunosController : Controller
    {
        AlunoRepositorio repositorio = new AlunoRepositorio();

        // GET: Alunos
        public ActionResult Index()
        {
            var alunos = repositorio.obterTodos().OrderBy(a => a.Matricula).ToList();

            return View(alunos);
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int matricula)
        {
            var aluno = repositorio.buscar(a => a.Matricula == matricula);

            if (aluno == null)
                return HttpNotFound("O Aluno consultado não foi encontrado.");

            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Aluno aluno = new Aluno();

                aluno.Matricula = Convert.ToInt32(collection["Matricula"]);
                aluno.Nome = collection["Nome"].ToString();
                aluno.CPF = collection["CPF"].ToString();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int id)
        {
            Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();

            if (aluno == null)
                return HttpNotFound("O Aluno consultado não foi encontrado.");

            return View(aluno);
        }

        // POST: Alunos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();

                if(aluno == null)
                    return HttpNotFound("O Aluno consultado não foi encontrado.");

                aluno.Nome = collection["Nome"].ToString();
                aluno.CPF = collection["CPF"].ToString();

                repositorio.atualizar(aluno);
                repositorio.SalvarTodos();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int id)
        {
            Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();

            if (aluno == null)
                return HttpNotFound("O Aluno consultado não foi encontrado.");

            return View(aluno);
            
        }

        // POST: Alunos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Aluno aluno = repositorio.buscar(a => a.Matricula == id).FirstOrDefault();

                if (aluno == null)
                    return HttpNotFound("O Aluno consultado não foi encontrado.");

                repositorio.excluir(a => a.Matricula == id);
                repositorio.SalvarTodos();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
