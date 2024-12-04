using Application.EntityAggregates;
using Application.RepositoryContracts;
using Domain.EntityAggregates;

namespace Application.ServicesContracts
{
    public interface IEntityService : IGenericService<Entity, EntityViewModel> 
    {
    }
}
