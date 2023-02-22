using Microsoft.EntityFrameworkCore;
using Model.File;

namespace Persistence.File
{
    public class FileRepository : GenericRepository<Model.File.File>, IFileRepository
    {
        public FileRepository(IDbContextFactory<PatientContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
