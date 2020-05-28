using F.Core.Model;

namespace F.Core.IService
{
    public interface IStudentService : IBaseService<Student>
    {
        bool InsertStudentAndTeacher(Student student, Teacher teacher);
    }
}