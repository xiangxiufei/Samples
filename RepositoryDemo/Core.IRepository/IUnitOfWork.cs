using Core.Model;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IUnitOfWork
    {
        MyDbContext GetDbContext();

        Task<int> SaveChangesAsync();
    }
}