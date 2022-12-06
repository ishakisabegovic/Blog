using Blog.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;

        }

        public IQueryable<T> GetAll() =>
             context.Set<T>();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
            context
            .Set<T>()
            .Where(expression);

        public void Create(T entity) => context.Set<T>().Add(entity);
        public void Update(T entity) => context.Set<T>().Update(entity);
        public void Delete(T entity) => context.Set<T>().Remove(entity);

    }

}
