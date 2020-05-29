using F.Core.IRepository;
using F.Core.IService;
using F.Core.Model;

namespace F.Core.Service
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly ITeacherRepository teacherRepository;

        public StudentService(IUnitOfWork unitOfWork, IBaseRepository<Student> currentRepository, ITeacherRepository teacherRepository) : base(unitOfWork, currentRepository)

        {
            this.teacherRepository = teacherRepository;
        }

        public bool UOW(Student student, Teacher teacher)
        {
            currentRepository.Add(student);
            teacherRepository.Add(teacher);

            unitOfWork.SaveChanges();

            return true;
        }
    }
}