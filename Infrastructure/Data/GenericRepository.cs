using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntitie {
        private readonly DataContext _context;
        public GenericRepository (DataContext context) {
            _context = context;
        }

        public async Task<T> GetByIdAsync (int id) {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync () {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }
        
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
           return await ApplySpec(spec).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpec(spec).CountAsync();
        }
        private IQueryable<T> ApplySpec(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }

       
    }
}