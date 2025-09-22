using E_Commerce_Inventory_API.Src.Domain.Interfaces;
using E_Commerce_Inventory_API.Src.Domain.Models;

namespace E_Commerce_Inventory_API.Services
{
   
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {

            var oldcategory = await _unitOfWork.Categorys.GetByName(category.Name);

            if (oldcategory.Any())

                throw new ArgumentException("category already exists");

            var newCategory = await _unitOfWork.Categorys.AddCategory(category);
            await _unitOfWork.CompleteAsync();

            return newCategory;
        }



        public async Task<List<CategoryModel>> GetAllCategoryAsync()
        {
            return await _unitOfWork.Categorys.GetAllCategory();
        }

        public async Task<List<CategoryModel>> GetCategoryByID(int id)
        {
            return await _unitOfWork.Categorys.GetCategoryByID(id);
        }

        public async Task<CategoryModel> UpdateCategoryByID(int id, CategoryModel category)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");

            var result = await _unitOfWork.Categorys.UpdateCategoryByID(id, category);
            if (result != null)
                await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<CategoryModel> DeleteCategoryByID(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");

            var category = await _unitOfWork.Categorys.DeleteCategoryByID(id);
            if (category != null)
                await _unitOfWork.CompleteAsync();
            return category;
        }
    }
}
