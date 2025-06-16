using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB_API_V04.Data;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Models;

namespace WEB_API_V04.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext context)
        {
            this.db = context;
        }
        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return await db.Products.AnyAsync(expression);
        }

        public async Task<Product> CreateAsync(Product newObject)
        {
            await db.Products.AddAsync(newObject);
            await db.SaveChangesAsync();

            return newObject;

        }

        public async Task<Product?> DeleteByIdAsync(int id)
        {
            var productToDelete = await db.Products.FirstOrDefaultAsync(pr => pr.ProductId == id);

            if (productToDelete == null) return null;

            db.Products.Remove(productToDelete);
            await db.SaveChangesAsync();

            return productToDelete;
        }

        public async Task<Product?> FirstOrDefaultAsync(Expression<Func<Product, bool>> expression)
        {
            return await db.Products.FirstOrDefaultAsync(expression);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await db.Products.Include(pr => pr.AuthorUser).Include(pr => pr.ProductCategory).Include(pr => pr.ProductImages).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await db.Products.Include(pr => pr.AuthorUser).Include(pr => pr.ProductCategory).Include(pr => pr.ProductImages).FirstOrDefaultAsync(pr => pr.ProductId == id);
        }

        public async Task<Product?> UpdateAsync(int id, Product updatedOjbect)
        {
            var productToUpdate = await db.Products.FirstOrDefaultAsync(pr => pr.ProductId == id);

            if (productToUpdate == null) return null;

            productToUpdate.ProductName = updatedOjbect.ProductName;
            productToUpdate.ProductDescription = updatedOjbect.ProductDescription;
            productToUpdate.Price = updatedOjbect.Price;
            productToUpdate.AuthorUserId = updatedOjbect.AuthorUserId;
            productToUpdate.ProductCategoryId = updatedOjbect.ProductCategoryId;

            await db.SaveChangesAsync();

            return productToUpdate;
        }

        public async Task<List<Product>> WhereAsync(Expression<Func<Product, bool>> expression)
        {
            return await db.Products.Include(pr => pr.AuthorUser).Include(pr => pr.ProductCategory).Where(expression).ToListAsync();
        }
    }
}
