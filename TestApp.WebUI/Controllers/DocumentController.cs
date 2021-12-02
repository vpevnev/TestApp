using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.BusinessLogic.Abstract;
using TestApp.BusinessLogic.BusinessModels.Inclusions;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.WebUI.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IDocumentTypeService documentTypeService;

        public DocumentController(IDocumentService documentService, IDocumentTypeService documentTypeService)
        {
            this.documentService = documentService;
            this.documentTypeService = documentTypeService;
        }

        public IActionResult Payer(string regNumber)
        {
            ViewBag.RegNumber = regNumber;

            List<PayerDocumentViewModel> viewModel = new();

            if (!string.IsNullOrWhiteSpace(regNumber))
            {
                IEnumerable<PayerDocumentDTO> payerDocumentDTOs = documentService.GetPayerDocuments(new RegNumber(regNumber));

                var mapper = new MapperConfiguration(config =>
                                                    {
                                                        config.CreateMap<FileEntityDTO, FileEntityViewModel>();
                                                        config.CreateMap<DocumentTypeDTO, DocumentTypeViewModel>();
                                                        config.CreateMap<PayerDocumentDTO, PayerDocumentViewModel>()
                                                            .ForMember(to => to.RegNumber, from => from.MapFrom(m => m.RegNumber.ToString()));
                                                    }).CreateMapper();

                viewModel = mapper.Map<IEnumerable<PayerDocumentDTO>, List<PayerDocumentViewModel>>(payerDocumentDTOs);
            }

            return View("PayerDocuments", viewModel);
        }

        public IActionResult Load()
        {
            IEnumerable<DocumentTypeDTO> documentTypes = documentTypeService.GetTypes(all => true);

            ViewBag.FileTypes = new SelectList(
                documentTypes.Select(e => new
                {
                    Id = e.DocumentTypeId,
                    Name = $"{e.ShortName} - {e.Name}"
                }), "Id", "Name");

            ViewBag.FileExtensions = new string[] {
                ".doc",
                ".docx",
                ".pdf",
                ".rtf" } as IEnumerable<string>;

            ViewBag.Title = "Загрузка документов";

            return View("LoadFiles");
        }

        [HttpPost]
        public IActionResult Load(string type, IFormFileCollection files, string regNumber = default)
        {
            // Формат RRR-DDD-NNNNNN
            int regNumberLength = 14;

            string rg;

            foreach (var file in files)
            {
                rg = regNumber ?? file.FileName.Substring(0, regNumberLength);

                documentService.Load(type, file, rg);
            }

            return RedirectToAction(nameof(Load));
        }
    }
}
