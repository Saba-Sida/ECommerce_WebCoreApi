using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB_API_V04.Data;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Models;

namespace WEB_API_V04.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db;

        public UserRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> expression)
        {
            return await db.Users.AnyAsync(expression);
        }

        public async Task<User> CreateAsync(User newObject)
        {
            await db.AddAsync(newObject);
            await db.SaveChangesAsync();

            return newObject;
        }

        public async Task<User?> DeleteByIdAsync(int id)
        {
            var user = await db.Users.FirstOrDefaultAsync(user => user.UserId == id);

            if (user == null) return null;

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return user;
        }

        public async Task<User?> FirstOrDefaultAsync(Expression<Func<User, bool>> expression)
        {
            return await db.Users.FirstOrDefaultAsync(expression);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await db.Users.Include(u => u.Products).ThenInclude(p => p.ProductImages).Include(u => u.Products).ThenInclude(p => p.ProductCategory).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await db.Users.Include(u => u.Products).ThenInclude(p => p.ProductImages).Include(u => u.Products).ThenInclude(p => p.ProductCategory).FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> UpdateAsync(int id, User updateOjbect)
        {
            var userToUpdate = await db.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (userToUpdate == null) return null;

            userToUpdate.UserName = updateOjbect.UserName;
            userToUpdate.EMail = updateOjbect.EMail;
            userToUpdate.PhoneNumber = updateOjbect.PhoneNumber;
            userToUpdate.Gender = updateOjbect.Gender;
            userToUpdate.ProfileImageUrl = updateOjbect.ProfileImageUrl;
            userToUpdate.PasswordHash = updateOjbect.PasswordHash;

            await db.SaveChangesAsync();

            return userToUpdate;
        }

        public async Task<List<User>> WhereAsync(Expression<Func<User, bool>> expression)
        {
            return await db.Users.Include(u => u.Products).ThenInclude(p => p.ProductImages).Where(expression).ToListAsync();
        }
    }
}
