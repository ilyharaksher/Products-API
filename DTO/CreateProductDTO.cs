using System.ComponentModel.DataAnnotations;

namespace Products_API.DTO
{
    // CreateProductDTO is used to create a new product with all required properties.
    public class CreateProductDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } // This property is required and cannot be null

        [Range(1, 100000)]
        public decimal? Price { get; set; }

        [Range(0, 1000)]
        public int? Quantity { get; set; }

        [Required]
        public string Category { get; set; } // This property is required and cannot be null

        [Required]
        [EmailAddress]
        public string ManufacturerEmail { get; set; } // This property is required and cannot be null

        [Phone]
        public string? ManufacturerPhone { get; set; } 
    }
}
