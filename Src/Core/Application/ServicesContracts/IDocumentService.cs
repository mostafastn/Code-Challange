using Application.RepositoryContracts;
using Domain.DocumentAggregates;
using Domain.EntityAggregates;

namespace Application.ServicesContracts
{
    public interface IDocumentService : IGenericRepository<Document>
    {
    }
}
