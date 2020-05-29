using F.Core.Model;

namespace F.Core.IService
{
    public interface IStudentService : IBaseService<Student>
    {
        bool UOW(Student student, Teacher teacher);
    }
}