using F.Core.IRepository;
using F.Core.Model;
using System;
using System.Threading.Tasks;

namespace F.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext mySqlContext;

        public UnitOfWork(MySqlContext mySqlContext)
        {
            this.mySqlContext = mySqlContext ?? throw new ArgumentNullException(nameof(mySqlContext));
        }

        public MySqlContext GetMySqlContext()
        {
            return mySqlContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await mySqlContext.SaveChangesAsync();
        }
    }
}