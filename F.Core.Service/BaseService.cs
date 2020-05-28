using F.Core.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace F.Core.Service
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseRepository<T> currentRepository;

        public T Add(T t)
        {
            return currentRepository.Add(t);
        }

        public bool Delete(T t)
        {
            return currentRepository.Delete(t);
        }

        public bool Update(T t)
        {
            return currentRepository.Update(t);
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> whereLambda)
        {
            return currentRepository.Select(whereLambda);
        }

        public IQueryable<T> Select<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return currentRepository.Select(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);
        }
    }
}