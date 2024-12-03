using Application.DocumentAggregates;
using Application.ProductAggregates;
using Application.RepositoryContracts;
using Application.ServicesContracts;
using AutoMapper;
using Domain.EntityAggregates;
using Domain.DocumentAggregates;

namespace Services.Services
{
    public class DocumentService : GenericService<Document, DocumentViewModel>, IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper)
            : base(documentRepository, mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

    }
}
