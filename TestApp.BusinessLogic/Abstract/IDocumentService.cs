using Microsoft.AspNetCore.Http;
using TestApp.BusinessLogic.BusinessModels.Inclusions;
using TestApp.BusinessLogic.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace TestApp.BusinessLogic.Abstract
{
    public interface IDocumentService
    {
        DocumentEntityDTO Get(Guid id);

        IEnumerable<PayerDocumentDTO> GetPayerDocuments(RegNumber regNumber);

        void Load(string documentType, IFormFile formFile, string regNumber = default);
    }
}
