using System.ComponentModel.DataAnnotations;

namespace Products_API.DTO
{
    // UpdateProductDTO is used to patch the product's price or quantity.
    public class UpdateProductDTO
    {
        [Range(1, 100000)]
        public decimal? Price { get; set; }

        [Range(0, 1000)]
        public int? Quantity { get; set; }
    }
}
