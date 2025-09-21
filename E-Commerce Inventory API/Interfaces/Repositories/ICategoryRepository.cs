using E_Commerce_Inventory_API.Models;

namespace E_Commerce_Inventory_API.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> AddCategory(CategoryModel category);
        Task<List<CategoryModel>> GetAllCategory();
        Task<List<CategoryModel>> GetCategoryByID( int id);
        Task<CategoryModel> DeleteCategoryByID(int id);
        Task<List<CategoryModel>> GetByName(string name);

        Task<CategoryModel> UpdateCategoryByID(int id,CategoryModel category);
    }
}
