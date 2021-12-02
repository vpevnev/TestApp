using TestApp.Domain.Abstract;
using TestApp.Domain.Data;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Concrete
{
    public class FileEntityRepository : Repository<FileEntity>, IFileEntityRepository
    {
        public FileEntityRepository(ApplicationDbContext context) 
            : base(context) 
        { }
    }
}
