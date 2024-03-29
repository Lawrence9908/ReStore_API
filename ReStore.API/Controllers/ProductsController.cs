using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReStore.API.Data;
using ReStore.API.Entities;
using System.Reflection.Metadata.Ecma335;

namespace ReStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet] //api/products/
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _storeContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")] //api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product  = await _storeContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(product);
        }

    }
}

