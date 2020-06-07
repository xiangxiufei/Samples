using F.Core.IRepository;
using F.Core.Model;
using System;
using System.Threading.Tasks;

namespace F.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext myDbContext;

        public UnitOfWork(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public MyDbContext GetDbSqlContext()
        {
            return myDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await myDbContext.SaveChangesAsync();
        }
    }
}