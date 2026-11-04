namespace Products_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; } // This property is required and cannot be null
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public required string Category { get; set; } // This property is required and cannot be null
        public required string ManufacturerEmail { get; set; } // This property is required and cannot be null
        public string? ManufacturerPhone { get; set; }
    }
}
