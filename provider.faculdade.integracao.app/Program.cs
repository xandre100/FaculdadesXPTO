using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using provider.faculdade.model.repositorio;
using provider.faculdade.model;

namespace provider.faculdade.integracao.app
{
    class Program
    {
        private static AlunoRepositorio alunoRep;

        static void Main(string[] args)
        {
            testaRepositorioAluno();
            Console.ReadKey();
        }

        private static void testaRepositorioAluno()
        {
            //criar
            Aluno aluno = new Aluno() { CPF = "1234", Matricula = 12345, Nome = "JOAQUIM", Grades = new List<Grade>() { } };
            
            alunoRep = new AlunoRepositorio();
            alunoRep.criar(aluno);
            alunoRep.SalvarTodos();

            Console.WriteLine("Aluno {0} criado", aluno.Nome);

            //atualizar
            aluno.Nome = "JOAQUIM SANTOS";

            alunoRep.atualizar(aluno);
            alunoRep.SalvarTodos();

            //consultar
            Aluno alunoRetornado = alunoRep.buscar(p => p.Matricula == 12345).FirstOrDefault();
            
            Console.WriteLine(alunoRetornado.Nome);
            Console.WriteLine("Aluno {0} atualizado", alunoRetornado.Nome);

            //excluir
            alunoRep.excluir(p => p.Matricula == 12345);
            alunoRep.SalvarTodos();

            Console.WriteLine("Aluno {0} excluído", alunoRetornado.Nome);
        }
    }
}
