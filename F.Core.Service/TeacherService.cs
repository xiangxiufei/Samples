using F.Core.IRepository;
using F.Core.Model;

namespace F.Core.Service
{
    public class TeacherService : BaseService<Teacher>, ITeacherRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITeacherRepository teacherRepository;

        public TeacherService(IUnitOfWork unitOfWork, ITeacherRepository teacherRepository)
        {
            this.unitOfWork = unitOfWork;
            base.currentRepository = teacherRepository;
        }
    }
}