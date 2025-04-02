using Microsoft.AspNetCore.Mvc;
using RefaelServer.Interfaces;
using RefaelServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RefaelServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }
       

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        // POST api/<ProductsController>
        [HttpPost("AddProduct")]
        public void Post([FromBody] Product value)
        {
            _productService.AddProduct(value);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("UpdateProduct")]
        public void Put( [FromBody] Product value)
        {
            _productService.UpdateProduct(value);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
