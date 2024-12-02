using Application.RepositoryContracts;
using Domain.DbEntity;
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
