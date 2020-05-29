using F.Core.IRepository;
using F.Core.IService;
using F.Core.Model;

namespace F.Core.Service
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITeacherRepository teacherRepository;
        private readonly IStudentRepository studentRepository;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            this.unitOfWork = unitOfWork;
            base.currentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
        }

        public bool InsertStudentAndTeacher(Student student, Teacher teacher)
        {
            currentRepository.Add(student);
            teacherRepository.Add(teacher);
            unitOfWork.SaveChanges();

            return true;
        }
    }
}