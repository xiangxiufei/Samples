using F.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task<int> Insert(T entity)
        {
            currentRepository.Insert(entity);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Insert(List<T> entities)
        {
            currentRepository.Insert(entities);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            currentRepository.Update(entity);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(List<T> entities)
        {
            currentRepository.Update(entities);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            currentRepository.Delete(entity);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(List<T> entities)
        {
            currentRepository.Delete(entities);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<T>> Select()
        {
            return await currentRepository.Select();
        }

        public async Task<List<T>> Select(Expression<Func<T, bool>> whereLambda)
        {
            return await currentRepository.Select(whereLambda);
        }

        public async Task<Tuple<List<T>, int>> Select<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return await currentRepository.Select(pageSize, pageIndex, whereLambda, orderByLambda, isAsc);
        }
    }
}