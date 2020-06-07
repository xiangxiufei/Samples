using F.Core.Model;
using System.Threading.Tasks;

namespace F.Core.IRepository
{
    public interface IUnitOfWork
    {
        MyDbContext GetDbSqlContext();

        Task<int> SaveChangesAsync();
    }
}