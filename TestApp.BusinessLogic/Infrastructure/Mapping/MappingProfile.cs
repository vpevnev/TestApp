using AutoMapper;
using TestApp.BusinessLogic.BusinessModels.Inclusions;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.Domain.Entities;

namespace TestApp.BusinessLogic.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Domain to Data Transfer Object
            {
                CreateMap<DocumentType, DocumentTypeDTO>();
                CreateMap<PayerDocument, PayerDocumentDTO>()
                    .ForMember(to => to.RegNumber, from => from.MapFrom(m => new RegNumber(m.RegnCode, m.DistCode, m.InsrNumber)));

                CreateMap<FileEntity, FileEntityDTO>();
            }
            #endregion

            #region Data Transfer Object to Domain
            {
                CreateMap<DocumentTypeDTO, DocumentType>();
                CreateMap<PayerDocumentDTO, PayerDocument>()
                    .ForMember(to => to.RegnCode, from => from.MapFrom(m => m.RegNumber.RegnCode))
                    .ForMember(to => to.DistCode, from => from.MapFrom(m => m.RegNumber.DistCode))
                    .ForMember(to => to.InsrNumber, from => from.MapFrom(m => m.RegNumber.InsrNumber));

                CreateMap<FileEntityDTO, FileEntity>();
            }
            #endregion

            #region Data Transfer Object to View Model
            {
                // Реализуется в WebUI
            }
            #endregion

            #region View Model to Data Transfer Object
            {
                // Реализуется в WebUI
            }
            #endregion
        }
    }
}
