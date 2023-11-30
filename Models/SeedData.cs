using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class SeedData
    {
        /// <summary>
        /// this static method ensures that all pending migrations have been applied to the database, if database is empty it is seeded with catagories, suppliers and products
        /// </summary>
        /// <param name="context">this is the data bass context used for the program</param>
        public static void seedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context.Products.Count() == 0
                    && context.Categories.Count() == 0
                        && context.Suppliers.Count() == 0) {
                
                Supplier s1 = new Supplier { Name = "name1", City = "city1" };
                Supplier s2 = new Supplier { Name = "name2", City = "city2" };
                Supplier s3 = new Supplier { Name = "name3", City = "city3" };

                Category c1 = new Category { Name = "category1" };
                Category c2 = new Category { Name = "category2" };
                Category c3 = new Category { Name = "category3" };


                context.Products.AddRange(
                    new Product {Name = "kayak", Price = 275, Category = c1, Supplier = s1 }
                    , new Product {Name = "LifeJacket", Price = 48.95m, Category = c1, Supplier = s1}
                    , new Product {Name = "Soccer Ball", Price = 19.50m, Category = c2, Supplier = s2 }
                    , new Product {Name = "Corner Flags", Price = 34.95m, Category = c2, Supplier = s2 }
                    , new Product {Name = "Stadium", Price = 79500, Category = c2, Supplier = s2 }
                    , new Product {Name = "Thinking Cap", Price = 16, Category = c3, Supplier = s3 }
                    , new Product {Name = "Unsteady Chair", Price = 29.95m, Category = c3, Supplier = s3 }
                    , new Product {Name = "Human Chess Board", Price = 75, Category = c3, Supplier = s3 }
                    , new Product {Name = "Bling-Bling King", Price = 1200, Category = c3, Supplier = s3 }

                    );
                context.SaveChanges();
            }
    }
}
}
