namespace Products_API.DTO
{
    // ProductResponseDTO is used to return the product's details in the response.
    public class ProductResponseDTO
    {
        public string Name { get; set; } // This property is required and cannot be null
        public decimal? Price { get; set; } 
        public int? Quantity { get; set; } 
        public string Category { get; set; } // This property is required and cannot be null
        public string ManufacturerEmail { get; set; } // This property is required and cannot be null
        public string? ManufacturerPhone { get; set; } 
    }
}
