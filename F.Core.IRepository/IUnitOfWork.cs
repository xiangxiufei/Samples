using F.Core.Model;
using System.Threading.Tasks;

namespace F.Core.IRepository
{
    public interface IUnitOfWork
    {
        MyDbContext GetDbContext();

        Task<int> SaveChangesAsync();
    }
}