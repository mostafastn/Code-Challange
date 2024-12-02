using Application.ProductAggregates;
using Application.RepositoryContracts;
using Application.ServicesContracts;

namespace Services.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        
    }
}
