using Application.RepositoryContracts;
using Domain.EntityAggregates;

namespace Application.ServicesContracts
{
    public interface IEntityService : IGenericRepository<Entity> 
    {
    }
}
