using RefaelServer.Interfaces;
using RefaelServer.Models;

namespace RefaelServer.Services
{
    public class ProductService : IProductService
    {
        private readonly Dictionary<int, Product> _products = new Dictionary<int, Product>();
        public ProductService() 
        {
            _products.Add(1, new Product { Id = 1, Name = "Laptop", Price = 10, Category = "Electronic", ImageUrl = @"assets/images/laptop.png" });
            _products.Add(2, new Product { Id = 2, Name = "T-shirt", Price = 12, Category = "Clothing", ImageUrl = @"assets/images/TShirt.png" });
            _products.Add(3, new Product { Id = 3, Name = "Smartphone", Price = 13, Category = "Electronic", ImageUrl = @"assets/images/smartphone.png" });
            _products.Add(4, new Product { Id = 4, Name = "jeens", Price = 14, Category = "Clothing", ImageUrl = @"assets/images/jeens.png" });
        }
        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                if (_products.ContainsKey(product.Id))
                {
                    LogService.LogError($"Product name: {product.Name} already exist");
                    return false;
            }
                _products.Add(product.Id, new Product { Id = product.Id, Name = product.Name, Price = product.Price, Category = product.Category, ImageUrl = product.ImageUrl });
                return true;
            }
            catch (Exception ex) 
            {
                LogService.LogError($"Exception when add Product name: {product.Name}, Error message: {ex.Message}");
                return false;
            }
           
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                if (!_products.ContainsKey(id))
                {
                    LogService.LogError($"Product id: {id} Not exist");
                    return false;
                }
                _products.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                LogService.LogError($"Exception when Remove Product id: {id}, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return _products.Values.ToList();
        }

        public  async Task<Product> GetProductById(int id)
        {
            return _products.Values.Where(o => o.Id == id).FirstOrDefault();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                if (_products.ContainsKey(product.Id))
                {
                    LogService.LogError($"Product name: {product.Name} already exist");
                    return false;
                }
                _products[product.Id] = new Product { Id = product.Id, Name = product.Name, Price = product.Price, Category = product.Category, ImageUrl = product.ImageUrl };
                return true;
            }
            catch (Exception ex)
            {
                LogService.LogError($"Exception when add Product name: {product.Name}, Error message: {ex.Message}");
                return false;
            }
        }
    }
}
