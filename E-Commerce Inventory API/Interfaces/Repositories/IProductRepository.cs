using E_Commerce_Inventory_API.Models;
namespace E_Commerce_Inventory_API.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProduct();
        Task<List<ProductModel>> ProductByID(int id);
        Task<ProductModel> AddProduct(ProductModel product);

        Task<List<ProductModel>> ProductByCategory(int categoryId);
        Task<List<ProductModel>> ProductByPriceRange(int minPrice, int maxPrice);
        Task<ProductModel> ProductDeleteByID(int id);
        Task<ProductModel> ProductUpdateByID(int id, ProductModel product);

        Task<List<ProductModel>>ProductSearchByKeyword(string keyword);
        Task<List<ProductModel>> Pagination(int page,int limit);

    }
}
