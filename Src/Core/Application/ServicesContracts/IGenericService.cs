﻿namespace Application.ServicesContracts
{
    public interface IGenericService<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task<TViewModel> GetByIdAsync(int id);
        Task<TViewModel> CreateAsync(TViewModel viewModel);
        Task DeleteAsync(int id);
    }
}
