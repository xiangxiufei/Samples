using F.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace F.Core.Repository
{
    public class BaseRepository<T> where T : class, new()
    {
        private readonly MyDbContext myDbContext;

        public BaseRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async ValueTask<EntityEntry<T>> Insert(T entity)
        {
            return await myDbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            myDbContext.Set<T>().Update(entity);
        }

        public async Task<int> Update(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity)
        {
            return await myDbContext.Set<T>().Where(whereLambda).UpdateAsync(entity);
        }

        public async Task<int> Delete(Expression<Func<T, bool>> whereLambda)
        {
            return await myDbContext.Set<T>().Where(whereLambda).DeleteAsync();
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> whereLambda)
        {
            return await myDbContext.Set<T>().AnyAsync(whereLambda);
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            return await myDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(whereLambda);
        }

        public async Task<List<T>> Select()
        {
            return await myDbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> Select(Expression<Func<T, bool>> whereLambda)
        {
            return await myDbContext.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<Tuple<List<T>, int>> Select<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            var total = await myDbContext.Set<T>().Where(whereLambda).CountAsync();

            if (isAsc)
            {
                var entities = await myDbContext.Set<T>().Where(whereLambda)
                                      .OrderBy<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

                return new Tuple<List<T>, int>(entities, total);
            }
            else
            {
                var entities = await myDbContext.Set<T>().Where(whereLambda)
                                      .OrderByDescending<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

                return new Tuple<List<T>, int>(entities, total);
            }
        }
    }
}