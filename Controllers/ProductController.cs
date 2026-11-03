using Microsoft.AspNetCore.Mvc;
using Products_API.Models;
using Products_API.DTO;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        //TODO: Implement interaction with the database, dbcontext, efcore via constructors and dependency injection.

        [HttpGet]
        public IActionResult GetProducts()
        {
            // TODO: add interaction with the database to retrieve products and return them as a list of ProductResponseDTO.
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            // TODO: add interaction with the database to retrieve a product by ID and return it as a ProductResponseDTO.
            return Ok();
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            // TODO: add interaction with the database to retrieve products by category and return them as a list of ProductResponseDTO.
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDTO createProductDTO)
        {
            // TODO: add interaction with the database to create a new product using the data from createProductDTO.

            var newProduct = new Product
            {
                Name = createProductDTO.Name,
                Price = createProductDTO.Price,
                Quantity = createProductDTO.Quantity,
                Category = createProductDTO.Category,
                ManufacturerEmail = createProductDTO.ManufacturerEmail,
                ManufacturerPhone = createProductDTO.ManufacturerPhone
            };

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = newProduct.Id },
                new
                {
                    Message = "Product created successfully",
                    Product = newProduct
                }
                );
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            // TODO: add interaction with the database to update an existing product using the data from updateProductDTO.
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // TODO: add interaction with the database to delete a product by ID.
            return Ok();
        }
    }
}
