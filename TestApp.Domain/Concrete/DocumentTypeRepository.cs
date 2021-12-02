using TestApp.Domain.Abstract;
using TestApp.Domain.Data;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Concrete
{
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(ApplicationDbContext context)
            : base (context)
        { }
    }
}
