using Core.IRepository;
using Core.Model;
using System;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext myDbContext;

        public UnitOfWork(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public MyDbContext GetDbContext()
        {
            return myDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await myDbContext.SaveChangesAsync();
        }
    }
}