using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<string> products = new() { "Apple", "Banana", "Orange" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string newProduct)
        {
            products.Add(newProduct);
            return Ok(products);
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= products.Count)
                return NotFound("Invalid index");

            products.RemoveAt(index);
            return Ok(products);
        }
    }
}
