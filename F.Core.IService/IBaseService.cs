using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace F.Core.IService
{
    public interface IBaseService<T> where T : class, new()
    {
        Task<int> Insert(T entity);

        Task<int> Insert(List<T> entities);

        Task<int> Update(T entity);

        Task<int> Update(List<T> entities);

        Task<int> Delete(T entity);

        Task<int> Delete(List<T> entities);

        Task<List<T>> Select();

        Task<List<T>> Select(Expression<Func<T, bool>> whereLambda);

        Task<Tuple<List<T>, int>> Select<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
    }
}