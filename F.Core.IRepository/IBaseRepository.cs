using System;
using System.Linq;
using System.Linq.Expressions;

namespace F.Core.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        T Add(T model);

        bool Delete(T model);

        bool Update(T model);

        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> Select<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        int SaveChanges();
    }
}