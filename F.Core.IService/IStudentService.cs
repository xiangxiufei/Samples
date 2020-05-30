using F.Core.Model;
using System.Threading.Tasks;

namespace F.Core.IService
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<bool> UOW(Student student, Teacher teacher);
    }
}