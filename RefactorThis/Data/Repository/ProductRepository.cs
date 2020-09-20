using refactor_me.Data.Interfaces;
using refactor_me.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace refactor_me.Data.Repository
{
    /// <summary>
    /// Product repository for all product and product options table operations
    /// </summary>
    /// <seealso cref = "IProductRepository" />
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _productContext;
        /// <summary>
        /// Initializes a new instance of the<see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name = "productContext" > The Product context.</param>
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> CreateProduct(Product model)
        {
            var addedProduct = _productContext.Products.Add(model);
            await _productContext.SaveChangesAsync();
            return addedProduct;
        }

        public async Task<ProductOption> CreateProductOption(ProductOption model)
        {
            var addedProductOption = _productContext.ProductOptions.Add(model);
            await _productContext.SaveChangesAsync();
            return addedProductOption;
        }

        public async Task DeleteProduct(Guid id)
        {
            var productModel = await GetProductsById(id);
            if (productModel == null)
                throw new NullReferenceException(nameof(productModel));

            _productContext.Products.Remove(productModel);
            await _productContext.SaveChangesAsync();
        }

        public async Task DeleteProductOption(Guid id)
        {
            var productOptionModel = await GetProductOptionById(id);
            if (productOptionModel == null)
                throw new NullReferenceException(nameof(productOptionModel));

            _productContext.ProductOptions.Remove(productOptionModel);
            await _productContext.SaveChangesAsync();
        }

        public async Task<ProductOption> GetProductOptionById(Guid id)
        {
            return await _productContext.ProductOptions.FirstOrDefaultAsync(prodOpt => prodOpt.Id == id);
        }

        public async Task<ProductOption> GetProductOptionByProductId(Guid productId)
        {
            return await _productContext.ProductOptions.FirstOrDefaultAsync(prodOpt => prodOpt.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var results = await _productContext.Products.ToListAsync();
            return results.AsQueryable();
        }

        public async Task<Product> GetProductsById(Guid id)
        {
            return await _productContext.Products.FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public async Task<Product> GetProductsByName(string name)
        {
            return await _productContext.Products.FirstOrDefaultAsync(prod => prod.Name == name);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updatedProduct = _productContext.Products.Attach(product);
            _productContext.Entry(product).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
            return updatedProduct;
        }

        public async Task<ProductOption> UpdateProductOption(ProductOption productOption)
        {
            var updatedProductOption = _productContext.ProductOptions.Attach(productOption);
            _productContext.Entry(productOption).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
            return updatedProductOption;
        }

    }
}