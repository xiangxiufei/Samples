using Core.IRepository;
using Core.Model;

namespace Core.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}