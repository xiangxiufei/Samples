using F.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace F.Core.Repository
{
    public class BaseRepository<T> where T : class, new()
    {
        private readonly MySqlContext mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            this.mySqlContext = mySqlContext;
        }

        public T Add(T model)
        {
            mySqlContext.Set<T>().Add(model);
            return model;
        }

        public bool Delete(T model)
        {
            mySqlContext.Entry(model).State = EntityState.Deleted;
            return true;
        }

        public bool Update(T model)
        {
            mySqlContext.Set<T>().Attach(model);
            mySqlContext.Entry(model).State = EntityState.Modified;
            return true;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> whereLambda)
        {
            return mySqlContext.Set<T>().Where(whereLambda).AsQueryable();
        }

        public IQueryable<T> Select<S>(int pageSize, int pageIndex,
            out int total, Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = mySqlContext.Set<T>().Where(whereLambda).Count();

            if (isAsc)
            {
                var temp = mySqlContext.Set<T>().Where(whereLambda)
                                      .OrderBy<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = mySqlContext.Set<T>().Where(whereLambda)
                                      .OrderByDescending<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).AsQueryable();
                return temp;
            }
        }
    }
}