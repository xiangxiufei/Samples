using F.Core.IRepository;
using F.Core.Model;

namespace F.Core.Service
{
    public class StudentService : BaseService<Student>, IStudentRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITeacherRepository teacherRepository;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            this.unitOfWork = unitOfWork;
            base.currentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
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