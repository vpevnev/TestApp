using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using TestApp.Domain.Abstract;
using TestApp.Domain.Data;
using System;
using System.Threading.Tasks;

namespace TestApp.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private DocumentEntityRepository documentEntityRepository;
        private DocumentTypeRepository documentTypeRepository;
        private FileEntityRepository fileEntityRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IDocumentEntityRepository Documents => documentEntityRepository ??= new DocumentEntityRepository(context);
        public IDocumentTypeRepository DocumentTypes => documentTypeRepository ??= new DocumentTypeRepository(context);

        public IFileEntityRepository FileEntities => fileEntityRepository ??= new FileEntityRepository(context);

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            context.Database.RollbackTransaction();
        }

        public EntityEntry Attach(object entity)
        {
            return context.Attach(entity);
        }

        public EntityEntry Entry(object entity)
        {
            return context.Entry(entity);
        }

        private readonly bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
