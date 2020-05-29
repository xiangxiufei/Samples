using F.Core.IRepository;
using F.Core.IService;
using F.Core.Model;

namespace F.Core.Service
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork, IBaseRepository<Teacher> currentRepository) : base(unitOfWork, currentRepository)
        {
        }
    }
}