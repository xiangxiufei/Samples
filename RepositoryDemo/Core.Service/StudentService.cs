using Core.IRepository;
using Core.IService;
using Core.Model;
using System.Threading.Tasks;

namespace Core.Service
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
            await currentRepository.Insert(student);
            await teacherRepository.Insert(teacher);

            await unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}