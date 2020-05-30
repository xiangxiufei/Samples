using F.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace F.Core.Repository
{
    public class BaseRepository<T> where T : class, new()
    {
        private readonly MySqlContext mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            this.mySqlContext = mySqlContext;
        }

        public void Insert(T entity)
        {
            mySqlContext.Set<T>().Add(entity);
        }

        public void Insert(List<T> entities)
        {
            mySqlContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            mySqlContext.Set<T>().Update(entity);
        }

        public void Update(List<T> entities)
        {
            mySqlContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            mySqlContext.Set<T>().Remove(entity);
        }

        public void Delete(List<T> entities)
        {
            mySqlContext.Set<T>().RemoveRange(entities);
        }

        public async Task<List<T>> Select()
        {
            return await mySqlContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> Select(Expression<Func<T, bool>> whereLambda)
        {
            return await mySqlContext.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<Tuple<List<T>, int>> Select<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            var total = await mySqlContext.Set<T>().Where(whereLambda).CountAsync();

            if (isAsc)
            {
                var entities = await mySqlContext.Set<T>().Where(whereLambda)
                                      .OrderBy<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

                return new Tuple<List<T>, int>(entities, total);
            }
            else
            {
                var entities = await mySqlContext.Set<T>().Where(whereLambda)
                                      .OrderByDescending<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

                return new Tuple<List<T>, int>(entities, total);
            }
        }
    }
}