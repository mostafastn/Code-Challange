using Application.DocumentAggregates;
using Domain.DocumentAggregates;

namespace Application.ServicesContracts
{
    public interface IDocumentService : IGenericService<Document, DocumentViewModel>
    {
    }
}
