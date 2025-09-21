using E_Commerce_Inventory_API.data;
using E_Commerce_Inventory_API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Inventory_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_Commerce_Inventory_API.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            await _context.Categorys.AddAsync(category);
            return category;
        }
        public async Task<List<CategoryModel>> GetByName(string name)
        {
           
            var category = await _context.Categorys.Where(c => c.Name == name).ToListAsync();

            return category;
        }

       

        public async Task<List<CategoryModel>> GetAllCategory()
        {
            return await _context.Categorys.ToListAsync();
        }

        public async Task<List<CategoryModel>> GetCategoryByID(int id)
        {
            return await _context.Categorys.Where(c => c.CategoryID == id).ToListAsync();
        }


        public async Task<CategoryModel> UpdateCategoryByID(int id, CategoryModel updatecategory)
        {
            var oldcategorys = await _context.Categorys.FindAsync(id);
            if (oldcategorys == null)
            
                return null;
            

            oldcategorys.Name = updatecategory.Name;
            oldcategorys.Description = updatecategory.Description;

            return oldcategorys;

        }
        public async Task<CategoryModel> DeleteCategoryByID(int id)
        {

            var category = await _context.Categorys.FindAsync(id);
            if (category == null)

                return null;

            bool hasProduct = await _context.Products.AnyAsync(p => p.CategoryID == id);

            if (hasProduct)
                return null;

            _context.Categorys.Remove(category);

            return category;


        }
    }

}
