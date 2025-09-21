using E_Commerce_Inventory_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using E_Commerce_Inventory_API.Src.Domain.Models;

namespace E_Commerce_Inventory_API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : ControllerBase

    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel category)
        {
            try
            {
                var addedCategory = await _categoryService.AddCategory(category);


                return Ok(new
                {
                    Message = "Category added successfully",
                    Data = addedCategory
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            var categories = await _categoryService.GetCategoryByID(id);
            if (categories == null || !categories.Any())

                return NotFound("not Category Found");

            return Ok(categories);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> CategoryUpdateID(int id, [FromBody] CategoryModel category)
        {
            try
            {
                var categorys = await _categoryService.UpdateCategoryByID(id, category);

                if (categorys == null)
                    return NotFound("Category not found.");

                return Ok("Category update successfully.");
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryByID(int id)
        {
            try
            {
                var category = await _categoryService.DeleteCategoryByID(id);

                if (category == null)
                    return StatusCode(409, "Category cannot be deleted because it has linked Products.");


                return Ok(new
                {
                    message = "Category deleted successfully.",

                });

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



    }
}
