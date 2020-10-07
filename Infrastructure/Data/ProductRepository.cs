using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class ProductRepository : IProductRepository {
        private readonly DataContext _context;
        public ProductRepository (DataContext context) {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync (int id) {
           return await  _context.Product.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync () {
           return await _context.Product.ToListAsync();
        }
    }
}