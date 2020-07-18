using Core.Model;
using System.Threading.Tasks;

namespace Core.IService
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<bool> UOW(Student student, Teacher teacher);
    }
}