namespace WebApp.Models
{
    //this class represents a Supplier
    public class Supplier
    {
        public long SupplierId { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public IEnumerable<Product>? products { get; set; }
    }
}
