using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace TestApp.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IDocumentEntityRepository Documents { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IFileEntityRepository FileEntities { get; }

        void Save();

        Task SaveAsync();

        IDbContextTransaction BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        EntityEntry Attach(object entity);

        EntityEntry Entry(object entity);
    }
}
