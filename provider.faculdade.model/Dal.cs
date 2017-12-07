using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provider.faculdade.model.dal
{
    public class Dal<T>: IDisposable, IDal<T> 
        where T : class
    {

        BaseContexto ctx = new BaseContexto();
        
        public Dal()
        {
        }

        public void atualizar(T entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> obterTodos()
        {
            return ctx.Set<T>();
        }

        public IQueryable<T> buscar(Func<T, bool> condicao)
        {
            return obterTodos().Where(condicao).AsQueryable();
        }

        public void criar(T entity)
        {
            ctx.Set<T>().Add(entity);
        }
        
        public void excluir(Func<T, bool> condicao)
        {
            ctx.Set<T>()
                .Where(condicao).ToList()
                .ForEach(del => ctx.Set<T>().Remove(del));
        }

        public void SalvarTodos()
        {
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
