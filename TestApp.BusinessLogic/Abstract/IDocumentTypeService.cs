using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestApp.BusinessLogic.Abstract
{
    public interface IDocumentTypeService
    {
        IEnumerable<DocumentTypeDTO> GetTypes(Expression<Func<DocumentType, bool>> predicate);
    }
}
