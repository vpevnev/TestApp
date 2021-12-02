using Microsoft.AspNetCore.Http;
using TestApp.BusinessLogic.Abstract;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.BusinessLogic.Infrastructure.Mapping;
using TestApp.Domain.Abstract;
using TestApp.Domain.Entities;
using System;
using System.IO;
using System.Linq.Expressions;

namespace TestApp.BusinessLogic.Services
{
    public class FileEntityService : IFileEntityService
    {
        IUnitOfWork Database { get; set; }

        public FileEntityService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public FileEntityDTO FormFileEntity(IFormFile formFile)
        {
            FileEntityDTO fileEntity = new();

            if (formFile != null)
            {
                fileEntity.FormFile = formFile;

                byte[] fileData = null;

                using (var binaryReader = new BinaryReader(formFile.OpenReadStream()))
                {
                    fileData = binaryReader.ReadBytes((int)formFile.Length);
                }

                fileEntity.FileData = fileData;
                fileEntity.FileName = Path.GetFileName(formFile.FileName);
                fileEntity.LoadTime = DateTime.Now;
            }

            return fileEntity;
        }

        public FileEntityDTO Get(Expression<Func<FileEntity, bool>> predicate)
        {
            Mapper.Map(Database.FileEntities.Get(predicate), out FileEntityDTO fileEntityDTO);

            return fileEntityDTO;
        }
    }
}
