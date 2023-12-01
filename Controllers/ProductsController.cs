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
        public IEnumerable<Product> GetProducts() {
            return context.Products;
        }

        [HttpGet("{id}")] //this one is saying that only a url with patter like /api/products/id
        public Product? GetProduct(long id, [FromServices] ILogger<ProductsController> logger) { //what does the logger service actually do?
            logger.LogInformation("GetProduct action invoked");
            return context.Products.Find(id);
        }

        [HttpPost]
        public void SaveProduct([FromBody] Product product) {
            context.Products.Add(product);
            context.SaveChanges();
        }

        [HttpPut]
        public void UpadateProduct([FromBody] Product product) {
            context.Products.Update(product);
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id) {
            context.Remove(new Product()
            {
                ProductId = id,
                Name = string.Empty
            });
            context.SaveChanges();
        }
    }
}
