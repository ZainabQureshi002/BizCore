using BizCore.Data;
using BizCore.Repository.IRepository;

namespace BizCore.Repository.RepositoryClass
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Products product)
        {
         await _context.Products.AddAsync(product); 
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Products product)
        {
            throw new NotImplementedException();
        }
    }
}