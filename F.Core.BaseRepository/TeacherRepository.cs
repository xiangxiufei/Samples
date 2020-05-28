using F.Core.IRepository;
using F.Core.Model;

namespace F.Core.BaseRepository
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }
    }
}