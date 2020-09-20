using System;
using System.Threading.Tasks;
using refactor_me.Data.Interfaces;
using refactor_me.Services;
using NUnit.Framework;
using refactor_me.Models.DbModel;
using RefactorThis.Tests.Repositories;

namespace RefactorThis.Tests
{
    internal static class ProductServiceTests
    {
        private static ProductService GetService(IProductRepository prodRepo)
        {
            return new ProductService(prodRepo);
        }

        [Test]
        public static async Task Create_Product_Valid()
        {
            //Setup
            var id = new Guid();
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);

            var product = new Product()
            {
                Id = id,
                Name = "Iphone",
                Description = "Iphone 10",
                Price = 150.28M,
                DeliveryPrice = 20.9M
            };

            //Action
            var result = await productService.CreateProduct(product);

            //Result
            Assert.IsTrue(productRepository.CreateProductDataCalled);
            Assert.IsNotNull(result);
        }

        [Test]
        public static async Task Create_ProductOption_Valid()
        {
            //Setup
            var id = new Guid();
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);

            var productOption = new ProductOption()
            {
                Name = "Iphone",
                Description = "Iphone 10",
            };

            //Action
            var result = await productService.CreateProductOption(new Guid("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"), productOption);

            //Result
            Assert.IsTrue(productRepository.CreateProductOptionDataCalled);
            Assert.IsNotNull(result);
        }

        [TestCase("Iphone")]
        public static async Task Get_Product_By_Name_Valid(string name)
        {
            //Setup
            var productName = name;
           
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);

            //Action
             await productService.GetProductsByName(productName);

            //Result
            Assert.IsTrue(productRepository.GetProductsByNameCalled);
            Assert.AreEqual(productName, productRepository.GetProductsByNameByName);
        }

        [Test]
        public static async Task Update_Product_Valid()
        {
            //Setup
            var id = new Guid("7d5d30db-94c6-40ce-91e7-49b0b49a67ed");
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);
            var product = new Product()
            {
                Price = 129.56M,
                DeliveryPrice = 90.89M,
            };

            //Action
            await productService.UpdateProduct(id,product);

            //Result
            Assert.IsTrue(productRepository.UpdateProductCalled);
        }

        [Test]
        public static async Task Update_ProductOption_Valid()
        {
            //Setup
            var id = new Guid("2a4800a3-e24f-49ef-a0f4-b82c730a0bb7");
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);
            var productOption = new ProductOption()
            {
                ProductId = new Guid("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Samsung Galaxy",
               Description = "Samsung Galaxy S11"
            };

            //Action
            await productService.UpdateProductOption(id, productOption);

            //Result
            Assert.IsTrue(productRepository.UpdateProductOptionCalled);
        }

        [TestCase("16ed39e4-1b91-4e0f-9289-45ea026fe4be")]
        public static async Task Get_ProductOption_By_ProductId_InValid(string id)
        {
            //Setup
            var productId = new Guid(id);
            var productOption = new ProductOption()
            {
                Id = Guid.Parse("2a4800a3-e24f-49ef-a0f4-b82c730a0bb7"),
                ProductId = Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Iphone",
                Description = "Iphone 10"
            };
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);

            //Action
            await productService.GetProductOptionByProductId(productId);

            //Result
            Assert.IsTrue(productRepository.GetProductOptionByProductIdCalled);
            Assert.AreNotEqual(productOption, productRepository.GetProductOptionByProductIdByProductId);
        }

        [TestCase("11111111-1111-1111-1111-111111111111")]
        public static async Task Get_ProductOption_By_Id_InValid(string id)
        {
            //Setup
            var productOptionId = new Guid(id);
            var productOption = new ProductOption()
            {
                Id = Guid.Parse("2a4800a3-e24f-49ef-a0f4-b82c730a0bb7"),
                ProductId = Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Iphone",
                Description = "Iphone 10"
            };
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);

            //Action
            await productService.GetProductOptionById(productOptionId);

            //Result
            Assert.IsTrue(productRepository.GetProductOptionByIdCalled);
            Assert.AreNotEqual(productOption, productRepository.GetProductOptionByIdById);
        }

        [TestCase("16ed39e4-1b91-4e0f-9289-45ea026fe4be")]
        public static async Task Get_Product_By_Id_InValid(string id)
        {
            //Setup
            var productId = new Guid(id);
            var product = new Product()
            {
                Id = Guid.Parse("7d5d30db-94c6-40ce-91e7-49b0b49a67ed"),
                Name = "Samsung",
                Description = "Samsung s10",
                Price = 200.90M,
                DeliveryPrice = 300.90M
            };
            var productRepository = new FakeProductRepository();
            var productService = GetService(productRepository);

            //Action
            await productService.GetProductsById(productId);

            //Result
            Assert.IsTrue(productRepository.GetProductsByIdCalled);
            Assert.AreNotEqual(product, productRepository.GetProductsByIdById);
        }
    }
}
