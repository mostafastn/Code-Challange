using Application.EntityAggregates;
using Application.RepositoryContracts;
using Application.ServicesContracts;
using AutoMapper;
using Domain.EntityAggregates;

namespace Services.Services
{
    public class EntityService : GenericService<Entity, EntityViewModel>, IEntityService
    {
        private readonly IMapper _mapper;
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository, IMapper mapper)
            : base(entityRepository, mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

    }
}
