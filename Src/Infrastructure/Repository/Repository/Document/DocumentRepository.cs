using Application.RepositoryContracts;
using efdb;

namespace Repository.Document
{
    public class DocumentRepository : GenericRepository<Domain.DocumentAggregates.Document>, IDocumentRepository
    {
        public DocumentRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
