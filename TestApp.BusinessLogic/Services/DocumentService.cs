using Microsoft.AspNetCore.Http;
using TestApp.BusinessLogic.Abstract;
using TestApp.BusinessLogic.BusinessModels.Inclusions;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.BusinessLogic.Infrastructure.Mapping;
using TestApp.Domain.Abstract;
using TestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.BusinessLogic.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IFileEntityService fileEntityService;

        IUnitOfWork Database { get; set; }

        public DocumentService(IUnitOfWork unitOfWork, IFileEntityService fileEntityService)
        {
            Database = unitOfWork;
            this.fileEntityService = fileEntityService;
        }

        public DocumentEntityDTO Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayerDocumentDTO> GetPayerDocuments(RegNumber regNumber)
        {
            IEnumerable<PayerDocument> payerDocuments = Database.Documents.GetPayerDocuments
                (regNumber.RegnCode, regNumber.DistCode, regNumber.InsrNumber);

            Mapper.Map(payerDocuments, out IEnumerable<PayerDocumentDTO> payerDocumentDTOs);

            return payerDocumentDTOs.OrderByDescending(e => e.FileEntity.LoadTime);
        }

        public void Load(string documentType, IFormFile formFile, string regNumberStr = default)
        {
            FileEntityDTO fileEntityDTO =
                    fileEntityService.FormFileEntity(formFile);
            
            Mapper.Map(fileEntityDTO, out FileEntity fileEntity);

            Database.BeginTransaction();
            try
            {
                if (regNumberStr != default)
                {
                    RegNumber regNumber = new(regNumberStr);

                    PayerDocumentDTO payerDocumentDTO = new()
                    {
                        RegNumber = regNumber,
                        DocumentTypeId = short.Parse(documentType),
                        FileEntityId = fileEntityDTO.FileEntityId
                    };

                    Mapper.Map(payerDocumentDTO, out PayerDocument payerDocument);
                    
                    Database.Documents.AddPayerDocument(payerDocument);
                }

                Database.FileEntities.Add(fileEntity);
                
                Database.Save();
                
                Database.CommitTransaction();
            }
            catch (Exception exception)
            {
                Database.RollbackTransaction();

                throw new Exception($"Во время загрузки произошла ошибка. {exception}");
            }
        }
    }
}
