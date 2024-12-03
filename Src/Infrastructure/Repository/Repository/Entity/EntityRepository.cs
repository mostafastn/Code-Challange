using Application.RepositoryContracts;
using Domain.EntityAggregates;
using efdb;

namespace Repository.Document
{
    public class EntityRepository : GenericRepository<Entity>, IEntityRepository
    {
        public EntityRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
