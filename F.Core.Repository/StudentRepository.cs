using F.Core.IRepository;
using F.Core.Model;

namespace F.Core.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}