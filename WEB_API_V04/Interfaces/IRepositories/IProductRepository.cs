using WEB_API_V04.Models;

namespace WEB_API_V04.Interfaces.IRepositories
{
    public interface IProductRepository : ICrud<Product>, IDBLinq<Product>
    {
    }
}
