using TestApp.BusinessLogic.Abstract;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.BusinessLogic.Infrastructure.Mapping;
using TestApp.Domain.Abstract;
using TestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestApp.BusinessLogic.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        IUnitOfWork Database { get; set; }

        public DocumentTypeService(IUnitOfWork unitOfWork)
            => Database = unitOfWork;

        public IEnumerable<DocumentTypeDTO> GetTypes(Expression<Func<DocumentType, bool>> predicate)
        {
            Mapper.Map(Database.DocumentTypes.GetRange(predicate), out IEnumerable<DocumentTypeDTO> documentTypeDTOs);

            return documentTypeDTOs.OrderBy(m => m.ShortName);
        }
    }
}
