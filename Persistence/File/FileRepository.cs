using Model.File;

namespace Persistence.File
{
    public class FileRepository : GenericRepository<Model.File.File>, IFileRepository
    {
        public FileRepository(PatientContext context) : base(context)
        {
        }
    }
}
