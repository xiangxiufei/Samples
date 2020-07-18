using Core.IRepository;
using Core.IService;
using Core.Model;

namespace Core.Service
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork, IBaseRepository<Teacher> currentRepository) : base(unitOfWork, currentRepository)
        {
        }
    }
}