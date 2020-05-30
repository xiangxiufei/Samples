using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace F.Core.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        void Insert(T entity);

        void Insert(List<T> entities);

        void Update(T entity);

        void Update(List<T> entities);

        void Delete(T entity);

        void Delete(List<T> entities);

        Task<List<T>> Select();

        Task<List<T>> Select(Expression<Func<T, bool>> whereLambda);

        Task<Tuple<List<T>, int>> Select<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
    }
}