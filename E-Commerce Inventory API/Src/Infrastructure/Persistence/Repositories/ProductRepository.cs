using E_Commerce_Inventory_API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Inventory_API.data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Commerce_Inventory_API.Src.Domain.Models;

namespace E_Commerce_Inventory_API.Repositories

{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<List<ProductModel>> ProductByID(int id)
        {
            return await _context.Products.Where(p => p.ProductID == id).ToListAsync();

        }


        public async Task<List<ProductModel>> ProductByCategory(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryID == categoryId).ToListAsync() ;

        }

        public async Task<List<ProductModel>> ProductByPriceRange(int minPrice,int maxPrice)
        {
            return await _context.Products.Where(p=>p.Price>=minPrice && p.Price <=maxPrice).ToListAsync();

        }

        public async Task<ProductModel> ProductDeleteByID(int id)
        {

            var product=  await _context.Products.FindAsync(id);
            if (product == null)

                  return null;

            _context.Products.Remove(product);

            return product;
           

        }
        public async Task<ProductModel> ProductUpdateByID(int id, ProductModel Updateproduct)
        {

            var oldProduct = await _context.Products.FindAsync(id);
            if (oldProduct == null)

                return null;

            oldProduct.Name = Updateproduct.Name;
            oldProduct.Description = Updateproduct.Description;
            oldProduct.Price = Updateproduct.Price;
            oldProduct.Stock = Updateproduct.Stock;
            oldProduct.CategoryID = Updateproduct.CategoryID;
            oldProduct.Image = Updateproduct.Image;

            return oldProduct;


        }

        public async Task<List<ProductModel>> ProductSearchByKeyword( string keyword)
        {

            if(string.IsNullOrEmpty(keyword))
                return new List<ProductModel>();

            var product = await _context.Products.Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword)).ToListAsync();
            return product;
            
        }

        public async Task<List<ProductModel>> Pagination(int page, int limit)
        {

            var skip = (page - 1) * limit;
            var product = await _context.Products.Skip(skip).Take(limit).ToListAsync();
            return product;

        }



    }
}
