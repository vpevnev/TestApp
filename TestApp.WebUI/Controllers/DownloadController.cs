using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using TestApp.BusinessLogic.Abstract;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.BusinessLogic.Infrastructure;

namespace TestApp.WebUI.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IFileEntityService fileEntityService;

        public DownloadController(IFileEntityService fileEntityService)
            => this.fileEntityService = fileEntityService;

        public IActionResult DownloadFileFromDb(Guid id)
        {
            FileEntityDTO fileEntity = fileEntityService.Get(e
                => e.FileEntityId == id);

            var contentType = Utilities.ContentTypes(Path.GetExtension(fileEntity.FileName));

            return File(fileEntity.FileData, contentType, fileEntity.FileName);
        }
    }
}
