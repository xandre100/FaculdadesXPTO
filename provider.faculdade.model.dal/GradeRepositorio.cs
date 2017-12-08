using provider.faculdade.model.dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provider.faculdade.model.repositorio
{
    public class GradeRepositorio : Dal<Grade>
    {
        public GradeRepositorio()
        {
            
        }

        public virtual IEnumerable<Grade> obterTodos()
        {
            return ctx.Set<Grade>().Include(g =>  g.Disciplina).Include(g => g.Semestre).Include(g => g.Turma).Include(g => g.Aluno); 
        }
    }
}
