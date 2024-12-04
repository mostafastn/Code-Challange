using Application.RepositoryContracts;
using Application.ServicesContracts;
using AutoMapper;

namespace Services.Services
{
    public class GenericService<TEntity, TViewModel> : IGenericService<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TEntity> _repository;


        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> CreateAsync(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            var result = await _repository.Add(entity);
            if (result != null)
                return viewModel;
            else
                return null;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var item = await _repository.FindAsync(id);
            if (item != null)
                await _repository.Delete(item);
            else
                throw new Exception("Not Found");

        }

        public virtual async Task<IEnumerable<TViewModel>> GetAllAsync()
        {
            var item = await _repository.GetAll();
            var viewModels = _mapper.Map<List<TViewModel>>(item);
            return viewModels;
        }

        public virtual async Task<TViewModel> GetByIdAsync(int id)
        {
            var item = await _repository.FindAsync(id);
            if (item != null)
            {
                var viewModel = _mapper.Map<TViewModel>(item);
                return viewModel;
            }
            else
                throw new Exception("Not Found");
        }
    }
}
