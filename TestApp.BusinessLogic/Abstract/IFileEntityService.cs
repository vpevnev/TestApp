using Microsoft.AspNetCore.Http;
using TestApp.BusinessLogic.DataTransferObjects;
using TestApp.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace TestApp.BusinessLogic.Abstract
{
    public interface IFileEntityService
    {
        /// <summary>
        /// Формирует сведения о файле
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        FileEntityDTO FormFileEntity(IFormFile formFile);

        FileEntityDTO Get(Expression<Func<FileEntity, bool>> predicate);
    }
}
