using System;
using System.Linq;
using System.Linq.Expressions;

namespace F.Core.IService
{
    public interface IBaseService<T> where T : class, new()
    {
        T Add(T t);

        bool Delete(T t);

        bool Update(T t);

        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> Select<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
    }
}