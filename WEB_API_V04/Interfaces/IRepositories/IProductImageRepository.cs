using WEB_API_V04.Models;

namespace WEB_API_V04.Interfaces.IRepositories
{
    public interface IProductImageRepository : ICrud<ProductImage>, IDBLinq<ProductImage>
    {
    }
}
