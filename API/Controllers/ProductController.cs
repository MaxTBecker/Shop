using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase {
        private readonly DataContext _context;
        public ProductController (DataContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task <ActionResult<List<Product>>> GetProduct () {
            var products = await _context.Product.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id) {

            return await _context.Product.FindAsync(id);
        }
    }
}