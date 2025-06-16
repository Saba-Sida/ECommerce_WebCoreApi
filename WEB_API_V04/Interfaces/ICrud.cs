namespace WEB_API_V04.Interfaces
{
    public interface ICrud<T>
    {
        Task<T> CreateAsync(T newObject);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> UpdateAsync(int id, T updatedOjbect);
        Task<T?> DeleteByIdAsync(int id);
    }
}
