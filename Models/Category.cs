namespace WebApp.Models
{   //this class represents a category
    public class Category
    {
        public long CategoryId { get; set; } //are these the getters and setters of the fields? 
        public required string Name { get; set; }
        public IEnumerable<Product>? products { get; set; } //what is this syntax right here?
    }
}
