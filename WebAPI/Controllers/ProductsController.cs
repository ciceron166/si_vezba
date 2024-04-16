using BusinessLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBusinessProduct businessProduct;

        public ProductsController(IBusinessProduct businessProduct)
        {
            this.businessProduct = businessProduct;
        }



        // GET: api/<ProductsController>
        [HttpGet("getall")]
        public async Task<List<Product>> Get()
        {
            return await businessProduct.GetAll();
        }

        // interval
        [HttpGet("{minPrice}/{maxPrice}")]
        public List<Product> GetInterval(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) return new List<Product>();
            return businessProduct.GetInterval(minPrice, maxPrice);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            return Ok(businessProduct.Insert(product));
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
