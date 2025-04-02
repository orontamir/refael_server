using RefaelServer.Models;

namespace RefaelServer.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

    }
}
