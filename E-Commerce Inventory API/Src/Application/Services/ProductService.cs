using E_Commerce_Inventory_API.Interfaces;
using E_Commerce_Inventory_API.Src.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_Commerce_Inventory_API.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
           
            var newProduct = await _unitOfWork.Products.AddProduct(product);
            await _unitOfWork.CompleteAsync();

            return newProduct;
        }


        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            return await _unitOfWork.Products.GetAllProduct();
        }

        public async Task<List<ProductModel>> ProductByID(int id)
        {
            return await _unitOfWork.Products.ProductByID(id);
        }

        public async Task<List<ProductModel>> ProductByCategory(int categoryId)
        {
            var products= await _unitOfWork.Products.ProductByCategory(categoryId);

            if (products == null|| !products.Any())
                throw new ArgumentException("No Product Found By Category");

            return products;
        }
        public async Task<List<ProductModel>> ProductByPriceRange(int minPrice, int maxPrice)
        {
            if (minPrice > maxPrice)

               throw new ArgumentException("minimum price cannot be grater than maximum price");
             
            var Products= await _unitOfWork.Products.ProductByPriceRange(minPrice, maxPrice);

            return Products;
        }

        public async Task<ProductModel> ProductDelect(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");

            var product= await _unitOfWork.Products.ProductDeleteByID(id);
            if (product != null)
                await _unitOfWork.CompleteAsync();
            return product;
        }

        public async Task<ProductModel> ProductUpdate(int id, ProductModel product)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");

            var result = await _unitOfWork.Products.ProductUpdateByID(id,product);
            if (result != null)
                await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<List <ProductModel>> ProductSearchByKeyword(string keyword)
        {
            if (keyword == null  )
                throw new ArgumentException("not found");

            var result = await _unitOfWork.Products.ProductSearchByKeyword(keyword);
            if (result != null)
                await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<List<ProductModel>> Pagination(int page, int limit)
        {
            var product = await _unitOfWork.Products.Pagination(page, limit);

            return product;


        }





    }
}
