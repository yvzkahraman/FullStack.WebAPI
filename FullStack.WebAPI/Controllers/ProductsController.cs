using FullStack.WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FullStack.WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// Next.js

        [Authorize(Roles ="Member")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ProductService.products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var product = ProductService.products.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound(new
                {
                    Message = "Product not found",
                    Value = id,
                });
            }


            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            if (model.Name == null)
            {
                return BadRequest();
            }

            var createdProduct = ProductService.Create(model.Name);
            return Created(string.Empty, createdProduct);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            ProductService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductService.Delete(id);
            return NoContent();
        }

        [HttpGet("GetFile")]
        public IActionResult GetFile()
        {
            string data = "text file dan gelen data";
            return File(Encoding.UTF8.GetBytes(data), "application/text");
        }

    }

    public class CreateProductModel
    {
        public string Name { get; set; } = null!;
    }
}


//Cokiee based JWT => Authentication.


// HASH => işiniz bitti, 
// a => md5 => 2,
// 2 => a



// Simetrik (key) => şifrelenen şeyi decode,
// Asimetrik (2 key) => şifrelene şeyi decode