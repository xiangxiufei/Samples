using F.Core.Model;

namespace F.Core.IRepository
{
    public interface IUnitOfWork
    {
        MySqlContext GetMySqlContext();

        int SaveChanges();
    }
}