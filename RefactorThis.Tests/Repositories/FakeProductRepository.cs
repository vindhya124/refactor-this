using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refactor_me.Data.Interfaces;
using refactor_me.Models.DbModel;

namespace RefactorThis.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public bool CreateProductDataCalled { get; private set; }
        public Product CreateProductDataProduct{ get; private set; }
        public Task<Product> CreateProduct(Product product)
        {
            CreateProductDataCalled = true;
            CreateProductDataProduct = product;
            return Task.FromResult(new Product());
        }

        public bool CreateProductOptionDataCalled { get; private set; }
        public ProductOption CreateProductOptionDataProductOption { get; private set; }
        public Task<ProductOption> CreateProductOption(ProductOption productOption)
        {
            CreateProductOptionDataCalled = true;
            CreateProductOptionDataProductOption = productOption;
            return Task.FromResult(new ProductOption());
        }

        public Task DeleteProduct(Guid id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteProductOption(Guid id)
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return Task.FromResult(Enumerable.Empty<Product>());
        }

        public bool GetProductOptionByIdCalled { get; private set; }
        public ProductOption GetProductOptionByIdById { get; private set; }
        public Task<ProductOption> GetProductOptionById(Guid id)
        {
            var productOption = new ProductOption()
            {
                Id = Guid.Parse("2a4800a3-e24f-49ef-a0f4-b82c730a0bb7"),
                ProductId = Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Iphone",
                Description = "Iphone 10"
            };
            GetProductOptionByIdCalled = true;
            GetProductOptionByIdById = productOption;
            if (id == Guid.Parse("2a4800a3-e24f-49ef-a0f4-b82c730a0bb7"))
                return Task.FromResult(productOption);
            return Task.FromResult(new ProductOption());
        }

        public bool GetProductOptionByProductIdCalled { get; private set; }
        public ProductOption GetProductOptionByProductIdByProductId { get; private set; }
        public Task<ProductOption> GetProductOptionByProductId(Guid productId)
        {
            var productOption = new ProductOption()
            {
                Id = Guid.Parse("2a4800a3-e24f-49ef-a0f4-b82c730a0bb7"),
                ProductId = Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Iphone",
                Description = "Iphone 10"
            };
            GetProductOptionByProductIdCalled = true;
            GetProductOptionByProductIdByProductId = productOption;
            if (productId == Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"))
                return Task.FromResult(productOption);
            return Task.FromResult(new ProductOption());
        }

        public bool GetProductsByIdCalled { get; private set; }
        public Product GetProductsByIdById { get; private set; }
        public Task<Product> GetProductsById(Guid id)
        {
            var product = new Product()
            {
                Id = Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Samsung",
                Description = "Samsung s10",
                Price = 200.90M,
                DeliveryPrice = 300.90M
            };
            GetProductsByIdCalled = true;
            GetProductsByIdById = product;
            if (id == Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"))
                return Task.FromResult(product);
            return Task.FromResult<Product>(null);
        }


        public bool GetProductsByNameCalled { get; private set; }
        public string GetProductsByNameByName { get; private set; }
        public Task<Product> GetProductsByName(string name)
        {
            GetProductsByNameCalled = true;
            GetProductsByNameByName = name;
            if (name == "Iphone")
                return Task.FromResult(new Product{Name = "Iphone", Description = "Iphone 10", Price = 120.78M});
            return Task.FromResult<Product>(null);
        }

        public bool UpdateProductCalled { get; private set; }
        public Task<Product> UpdateProduct(Product product)
        {
            UpdateProductCalled = true;
            return Task.FromResult(new Product());
        }

        public bool UpdateProductOptionCalled { get; private set; }
        public Task<ProductOption> UpdateProductOption(ProductOption productOption)
        {
            UpdateProductOptionCalled = true;
            return Task.FromResult(new ProductOption());
        }
    }
}
