using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provider.faculdade.model.dal
{
    public interface IDal<T> where T : class 
    {
        void criar(T entity);
        IEnumerable<T> obterTodos();
        IQueryable<T> buscar(Func<T, bool> condicao);
        void atualizar(T entity);
        void excluir(Func<T, bool> condicao);
        void SalvarTodos();
    }
}
