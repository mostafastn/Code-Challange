using Application.ProductAggregates;
using Application.RepositoryContracts;
using Application.ServicesContracts;
using Repository.Document;

namespace Services.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        
    }
}
