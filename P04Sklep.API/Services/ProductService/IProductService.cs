using P05Sklep.Shared;

namespace P04Sklep.API.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<Product[]>> GetProductAsync();
        Task<ServiceResponse<Product>> UpdateProduct(Product product);
        Task<ServiceResponse<bool>> DeleteProductAsync(int id);
        Task<ServiceResponse<Product>> CreateProductAsync(Product product);
    }
}
