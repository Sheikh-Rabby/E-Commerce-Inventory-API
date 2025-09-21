using E_Commerce_Inventory_API.Models;
using E_Commerce_Inventory_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Inventory_API.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {

            try
            {
                var products = await _productService.AddProduct(product);

                if (product != null)

                    return Ok(new
                    {
                        message = "product Added",
                        data = product

                    });


                return Ok(products);
            }
            catch
            {
                return StatusCode(500, new { message = "Failed to add product" });
            }

           
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> ProductById(int id)
        {
            try
            {
                var products = await _productService.ProductByID(id);

                if (products == null || !products.Any())

                    return NotFound("Product not found");

                return Ok(products);
            }
            catch(Exception e)
            {
                return StatusCode(404, new { Message = e.Message });
            }
           
        }




        [HttpGet("By category")]
        public async Task<IActionResult> ProductByCategory( [FromQuery]int categoryId)
        {
            try
            {
                var products = await _productService.ProductByCategory(categoryId);

                if (products == null || !products.Any())
                    return NotFound(new { Message = "No products found for this category." });

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(404, new { Message = ex.Message });
            }
        }



        [HttpGet("By price range")]
        public async Task<IActionResult> productbycategory([FromQuery] int minPrice, [FromQuery] int maxPrice)
        {
            try
            {
                var products = await _productService.ProductByPriceRange(minPrice, maxPrice);

                if (products == null || !products.Any())
                {
                    return NotFound("No Product Found for this price range");
                }

                return Ok(products);

            }
            catch (Exception e)
            {
                return StatusCode(404, "" + e.Message);
            }


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductDeleteByID(int id)
        {
            try
            {
                var products = await _productService.ProductDelect(id); 

                if (products ==null )
                    return NotFound("Product not found.");

                return Ok("Product deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ProductUpdateID(int id ,[FromBody] ProductModel product)
        {
            try
            {
                var products = await _productService.ProductUpdate(id,product);

                if (products == null)
                    return NotFound("Product not found.");

                return Ok("Product update successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }



        [HttpGet("search")]
        public async Task<IActionResult> ProductSearchByKeyword([FromQuery] string q)
        {
            try
            {
                var products = await _productService.ProductSearchByKeyword(q);

                if (products == null || !products.Any())
                    return NotFound(new { Message = "No products found for this category." });

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(404, new { Message = ex.Message });
            }
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var products = await _productService.Pagination(page, limit);

                if (products == null || !products.Any())
                    return NotFound("No Product Found");

                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



    }
}
