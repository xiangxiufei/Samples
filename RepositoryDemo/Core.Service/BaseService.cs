using Core.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Service
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
            await currentRepository.Insert(entity);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            currentRepository.Update(entity);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity)
        {
            await currentRepository.Update(whereLambda, entity);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(Expression<Func<T, bool>> whereLambda)
        {
            await currentRepository.Delete(whereLambda);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> whereLambda)
        {
            return await currentRepository.IsExist(whereLambda);
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            return await currentRepository.GetEntity(whereLambda);
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