using TestApp.Domain.Entities;
using System.Collections.Generic;

namespace TestApp.Domain.Abstract
{
    public interface IDocumentEntityRepository
    {
        List<PayerDocument> GetPayerDocuments(short regnCode, short distCode, int insrNumber);

        void AddPayerDocument(PayerDocument payerDocument);

        void AddRangePayerDocuments(IEnumerable<PayerDocument> payerDocuments);
    }
}
