using refactor_me.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Interfaces
{
   public interface IProductRepository
   {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductsByName(string name);
        Task<Product> GetProductsById(Guid id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
        Task<ProductOption> GetProductOptionByProductId(Guid productId);
        Task<ProductOption> GetProductOptionById(Guid id);
        Task<ProductOption> CreateProductOption(ProductOption productOption);
        Task<ProductOption> UpdateProductOption(ProductOption productOption);
        Task DeleteProductOption(Guid id);

    }
}
