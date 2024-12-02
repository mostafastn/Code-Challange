using Application.RepositoryContracts;
using Domain.DocumentAggregates;
using efdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Document
{
    public class DocumentRepository : GenericRepository<Domain.DocumentAggregates.Document>, IDocumentRepository
    {
        public DocumentRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
