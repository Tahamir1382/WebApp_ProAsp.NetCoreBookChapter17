using WebApp.Models;

namespace WebApp
{
    public class TestMiddleware
    {
        //the idea of delegates and what its actually doing is kinda of unclear?
        private RequestDelegate nextDelegate;

        public TestMiddleware(RequestDelegate next) {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context, DataContext dataContext) { //what is invoke and what is task
            if (context.Request.Path == "/test")
            {
                await context.Response.WriteAsync($"There are " + dataContext.Products.Count() + " products\n");
                await context.Response.WriteAsync($"There are " + dataContext.Categories.Count() + " categories\n");
                await context.Response.WriteAsync($"There are " + dataContext.Suppliers.Count() + " supplier\n"); ;
            }
            else {
                await nextDelegate(context);
            }
        }
    }
}
