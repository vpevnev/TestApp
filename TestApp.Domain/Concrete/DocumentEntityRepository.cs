using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Abstract;
using TestApp.Domain.Data;
using TestApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.Domain.Concrete
{
    public class DocumentEntityRepository : IDocumentEntityRepository
    {
        private readonly ApplicationDbContext context;

        public DocumentEntityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddPayerDocument(PayerDocument payerDocument)
        {
            context.PayerDocuments.Add(payerDocument);
        }

        public void AddRangePayerDocuments(IEnumerable<PayerDocument> payerDocuments)
        {
            context.PayerDocuments.AddRange(payerDocuments);
        }

        public List<PayerDocument> GetPayerDocuments(short regnCode, short distCode, int insrNumber)
        {
            return context.PayerDocuments
                .Include(e => e.FileEntity)
                .Include(e => e.DocumentType)
                .Where(e => e.RegnCode == regnCode
                        && e.DistCode == distCode
                        && e.InsrNumber == insrNumber)
                .OrderByDescending(e => e.FileEntity.LoadTime)
                .ToList();
        }
    }
}
