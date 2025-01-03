namespace BizCore.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<IEnumerable<Products>> GetByIdAsync(int Id);
        Task AddAsync(Products product);    
        Task UpdateAsync(Products product);
        Task DeleteAsync(int id);

    }
}
