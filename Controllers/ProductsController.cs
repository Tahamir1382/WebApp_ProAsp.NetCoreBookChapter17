using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext context;
        public ProductsController(DataContext ctx) {
            context = ctx;
        }

        [HttpGet] //so these are attributes that are applied to an action this one means just a normal httpget with url like api/products
        public IAsyncEnumerable<Product> GetProducts() {
            return context.Products.AsAsyncEnumerable();
        }

        [HttpGet("{id}")] //this one is saying that only a url with patter like /api/products/id
        public async Task<Product?> GetProduct(long id, [FromServices] ILogger<ProductsController> logger) { //what does the logger service actually do?
            logger.LogInformation("GetProduct action invoked");
            return await context.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task SaveProduct([FromBody] Product product) {
            await context.Products.FindAsync(product);
            await context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpadateProduct([FromBody] Product product) {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(long id) {
            context.Remove(new Product()
            {
                ProductId = id,
                Name = string.Empty
            });
            await context.SaveChangesAsync();
        }
    }
}
