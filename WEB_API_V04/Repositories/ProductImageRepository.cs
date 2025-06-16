using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB_API_V04.Data;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Models;

namespace WEB_API_V04.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private ApplicationDbContext db;
        public ProductImageRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<ProductImage, bool>> expression)
        {
            return await db.ProductImages.AnyAsync(expression);
        }

        public async Task<ProductImage> CreateAsync(ProductImage newObject)
        {
            await db.ProductImages.AddAsync(newObject);
            await db.SaveChangesAsync();

            return newObject;
        }

        public async Task<ProductImage?> DeleteByIdAsync(int id)
        {
            var imageToDelete = await db.ProductImages.FirstOrDefaultAsync(image => image.ProductImageId == id);
            
            if (imageToDelete == null) return null;

            db.ProductImages.Remove(imageToDelete);
            await db.SaveChangesAsync();

            return imageToDelete;
        }

        public async Task<ProductImage?> FirstOrDefaultAsync(Expression<Func<ProductImage, bool>> expression)
        {
            return await db.ProductImages.FirstOrDefaultAsync(expression);
        }

        public async Task<List<ProductImage>> GetAllAsync()
        {
            return await db.ProductImages.ToListAsync();
            //return await db.ProductImages.Include(image => image.product).ToListAsync();
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await db.ProductImages.FirstOrDefaultAsync(image => image.ProductImageId == id);
            //return await db.ProductImages.Include(image => image.product).FirstOrDefaultAsync(image => image.ProductImageId == id);
        }

        public async Task<ProductImage?> UpdateAsync(int id, ProductImage updatedOjbect)
        {
            var imageToUpdate = await db.ProductImages.FirstOrDefaultAsync(image => image.ProductImageId == id);

            if (imageToUpdate == null) return null;

            imageToUpdate.ProductImageUrl = updatedOjbect.ProductImageUrl;
            imageToUpdate.ProductId = updatedOjbect.ProductId;

            await db.SaveChangesAsync();

            return imageToUpdate;
        }

        public async Task<List<ProductImage>> WhereAsync(Expression<Func<ProductImage, bool>> expression)
        {
            return await db.ProductImages.Where(expression).ToListAsync();
        }
    }
}
