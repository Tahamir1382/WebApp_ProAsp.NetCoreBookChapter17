using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    //this class represents a Product which is i assume our fact table
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; } 
        [Column(TypeName = "decimal(8, 2)")] //are we giving it additional data? like how this attribute behaves? ; it says it represent the column that the property is mapped to
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public Category? Category { get; set; }


        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; } 

    }
}
