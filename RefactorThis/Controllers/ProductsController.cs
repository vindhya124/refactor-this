using System;
using System.Threading.Tasks;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Models.DbModel;
using refactor_me.Services.Interfaces;
using refactor_me.Services;

namespace refactor_me.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("api/Products/GetAllProducts")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var product = await _productService.GetAllProducts();
            if (product != null)
                return Ok(product);
            return BadRequest();
        }

        [HttpGet]
        [Route("api/Products/GetProductByName/{name}")]
        public async Task<IHttpActionResult> GetProductByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var product = await _productService.GetProductsByName(name);
                if (product != null)
                    return Ok(product);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/Products/GetProduct/{id}")]
        public async Task<IHttpActionResult> GetProductById(Guid id)
        {
            if (id != Guid.Empty)
            {
                var product = await _productService.GetProductsById(id);
                if (product != null)
                    return Ok(product);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/Products/Create")]
        public async Task<IHttpActionResult> Create([FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProduct(model);
                if (product != null)
                    return Ok(product);
            }
            return BadRequest();
        }


        [HttpPut]
        [Route("api/Products/UpdateProduct/{id}")]
        public async Task<IHttpActionResult> UpdateProduct(Guid id, [FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateProduct(id, model);
                if (product != null)
                    return Ok(product);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Products/DeleteProduct/{id}")]
        public async Task DeleteProduct(Guid id)
        {
            await _productService.DeleteProduct(id);
        }

        [HttpGet]
        [Route("api/Products/GetProductOptionByProductId/{productId}")]
        public async Task<IHttpActionResult> GetProductOptionByProductId(Guid productId)
        {
            if (productId != Guid.Empty)
            {
                var productOption = await _productService.GetProductOptionByProductId(productId);
                if (productOption != null)
                    return Ok(productOption);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/Products/GetProductOption/{id}")]
        public async Task<IHttpActionResult> GetProductOptionById(Guid id)
        {
            if (id != Guid.Empty)
            {
                var productOption = await _productService.GetProductOptionById(id);
                if (productOption != null)
                    return Ok(productOption);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/Products/CreateProductOption/{productId}")]
        public async Task<IHttpActionResult> CreateProductOption(Guid productId, [FromBody]ProductOption model)
        {
            if (ModelState.IsValid)
            {
                var productOption = await _productService.CreateProductOption(productId, model);
                if (productOption != null)
                    return Ok(productOption);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Products/UpdateProductOption/{id}")]
        public async Task<IHttpActionResult> UpdateProductOption(Guid id, [FromBody]ProductOption model)
        {
            if (ModelState.IsValid)
            {
                var productOption = await _productService.UpdateProductOption(id, model);
                if (productOption != null)
                    return Ok(productOption);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Products/DeleteProductOption/{id}")]
        public async Task DeleteProductOption(Guid id)
        {
            await _productService.DeleteProductOption(id);
        }
    }
}
