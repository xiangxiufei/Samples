using F.Core.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace F.Core.Service
{
    public class BaseService<T> where T : class, new()
    {
        protected IUnitOfWork unitOfWork;
        protected IBaseRepository<T> currentRepository;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> currentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.currentRepository = currentRepository;
        }

        public bool Add(T t)
        {
            currentRepository.Add(t);
            return unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(T t)
        {
            currentRepository.Delete(t);
            return unitOfWork.SaveChanges() > 0;
        }

        public bool Update(T t)
        {
            currentRepository.Update(t);
            return unitOfWork.SaveChanges() > 0;
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