using F.Core.Model;
using System.Threading.Tasks;

namespace F.Core.IRepository
{
    public interface IUnitOfWork
    {
        MySqlContext GetMySqlContext();

        Task<int> SaveChangesAsync();
    }
}