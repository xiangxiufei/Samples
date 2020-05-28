using F.Core.IRepository;
using F.Core.Model;

namespace F.Core.BaseRepository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }
    }
}