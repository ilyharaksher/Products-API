using Microsoft.AspNetCore.Mvc;
using Products_API.Models;
using Products_API.DTO;
using Products_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        //TODO: Implement interaction with the database, dbcontext, efcore via constructors and dependency injection.

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // TODO: add interaction with the database to retrieve products and return them as a list of ProductResponseDTO.

            var products = await _context.Products.Select(p => new ProductResponseDTO
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                Category = p.Category,
                ManufacturerEmail = p.ManufacturerEmail,
                ManufacturerPhone = p.ManufacturerPhone
            })
            .ToListAsync();
            if (products.Any())
            {
                return Ok(new
                {
                    Message = "Here's all the products",
                    Products = products
                });
            }
            else
            {
                return Ok(new { Message = "There are no products... yet" });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            // TODO: add interaction with the database to retrieve a product by ID and return it as a ProductResponseDTO.

            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductResponseDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Category = p.Category,
                    ManufacturerEmail = p.ManufacturerEmail,
                    ManufacturerPhone = p.ManufacturerPhone
                })
                .FirstOrDefaultAsync();

            if (product is not null)
            {
                return Ok(new
                {
                    Message = "Here's the product you're looking for",
                    Result = product
                });
            }
            else
            {
                return NotFound(new { Message = "Not found" });
            }
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            // TODO: add interaction with the database to retrieve products by category and return them as a list of ProductResponseDTO.

            var products = await _context.Products
                .Where(p => p.Category == category)
                .Select(p => new ProductResponseDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Category = p.Category,
                    ManufacturerEmail = p.ManufacturerEmail,
                    ManufacturerPhone = p.ManufacturerPhone
                })
                .ToListAsync();

            if (products.Any())
            {
                return Ok(new
                {
                    Message = "Here's all the products within the wanted category",
                    Products = products
                });
            }
            else
            {
                return NotFound(new { Message = "There are no products in this category yet" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO createProductDTO)
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

            _context.Add(newProduct);

            await _context.SaveChangesAsync();

            var response = new ProductResponseDTO
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                Quantity = newProduct.Quantity,
                Category = newProduct.Category,
                ManufacturerEmail = newProduct.ManufacturerEmail,
                ManufacturerPhone = newProduct.ManufacturerPhone
            };

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = newProduct.Id },
                new
                {
                    Message = "Product created successfully",
                    Product = response
                }
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO dto)
        {
            // TODO: add interaction with the database to update an existing product using the data from updateProductDTO.
            // Early return approach is more preferable

            var product = await _context.Products.FindAsync(id);

            if (product is not null)
            {
                if (dto.Price is not null || dto.Quantity is not null)
                {
                    if (dto.Price is not null)
                    {
                        product.Price = dto.Price;
                    }

                    if (dto.Quantity is not null)
                    {
                        product.Quantity = dto.Quantity;
                    }

                    await _context.SaveChangesAsync();

                    return Ok(new
                    {
                        Message = "Object updated successfully!"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "At least one field must be provided for update."
                    });
                }
            }
            else
            {
                return NotFound(new { Message = "Not found, cannot Update" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // TODO: add interaction with the database to delete a product by ID.

            var product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound(new { Message = "Not found, cannot Delete" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Product deleted successfully" });

        }
    }
}
