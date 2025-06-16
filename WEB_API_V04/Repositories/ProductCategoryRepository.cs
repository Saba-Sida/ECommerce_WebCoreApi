using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB_API_V04.Data;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Models;

namespace WEB_API_V04.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private ApplicationDbContext db;
        public ProductCategoryRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            return await db.ProductCategories.AnyAsync(expression);
        }

        public async Task<ProductCategory> CreateAsync(ProductCategory newObject)
        {
            await db.ProductCategories.AddAsync(newObject);
            await db.SaveChangesAsync();

            return newObject;
        }

        public async Task<ProductCategory?> DeleteByIdAsync(int id)
        {
            var objectToDelete = await db.ProductCategories.FirstOrDefaultAsync(category => category.ProductCategoryId == id);

            if (objectToDelete == null) return null;

            db.ProductCategories.Remove(objectToDelete);
            await db.SaveChangesAsync();

            return objectToDelete;
        }

        public async Task<ProductCategory?> FirstOrDefaultAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            return await db.ProductCategories.Include(category => category.ParentProductCategory).FirstOrDefaultAsync(expression);
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await db.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await db.ProductCategories.FirstOrDefaultAsync(category => category.ProductCategoryId == id);
        }

        public async Task<ProductCategory?> UpdateAsync(int id, ProductCategory updatedOjbect)
        {
            var categoryToUpdate = await db.ProductCategories.FirstOrDefaultAsync(c => c.ProductCategoryId == id);

            if (categoryToUpdate == null) return null;

            categoryToUpdate.ProductCategoryTitle = updatedOjbect.ProductCategoryTitle;
            categoryToUpdate.ParentProductCategory = updatedOjbect.ParentProductCategory;

            await db.SaveChangesAsync();

            return categoryToUpdate;
        }

        public async Task<List<ProductCategory>> WhereAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            return await db.ProductCategories.Where(expression).ToListAsync();
        }
    }
}
