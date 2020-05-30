using F.Core.IRepository;
using F.Core.IService;
using F.Core.Model;
using System.Threading.Tasks;

namespace F.Core.Service
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly ITeacherRepository teacherRepository;

        public StudentService(IUnitOfWork unitOfWork, IBaseRepository<Student> currentRepository, ITeacherRepository teacherRepository) : base(unitOfWork, currentRepository)

        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<bool> UOW(Student student, Teacher teacher)
        {
            currentRepository.Insert(student);
            teacherRepository.Insert(teacher);

            await unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}