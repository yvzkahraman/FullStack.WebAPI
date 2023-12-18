using FullStack.WebAPI.Data;
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
        // localhost : ???? /api/Products


        [HttpGet]
        public IActionResult Get()
        {
            // Success Status Code 200...

            //response.IsSuccessStatusCode

            // 200 OK 201 Created 204 NoContent 400 BadRequest 404 NotFound 500 Problem
            // 


            // => Veri çekerken  bu işlem başarılı ise => 200
            // => Eklerken => bu işlem başarılı => 201 (geri dönersiniz)
            // => Silme => silme işlemi başarılı ise => 204 
            // => Update => update işlemi başarıl ise => 204 


            // İşlem başarıszsa ? 
            // Veriyi bulamadık => 404 => NotFound
            // Atılan request istedğimiz gibi değil => 400 Bad Request
            // UnAuthorized =>  401 | 403
            // Database patladı, connection pool şişti vs vs. 500 => Problem


            // V8 Engine + Javacsript 
            // npm => node package manager
            // Node.js  || 

            // throw new Exception("Bir hata oluştu");

            return Ok(ProductService.products);

            //return BadRequest();
            //return Ok(new { Id = 1, Name = "Iphone 15" });

        }

        //[HttpGet("GetProductsByCategory/{categoryId}")]
        //public IActionResult GetProductsByCategoryId(int categoryId)
        //{
        //    var products = ProductService.products.Where(x => x.CategoryId == categoryId).ToList();

        //    foreach (var product in products)
        //    {
        //        product.Category = ProductService.categories.SingleOrDefault(x => x.Id == product.CategoryId) ?? new Category();
        //    }

        //    return Ok(products);
        //}

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

    //public class TestController : Controller
    //{

    //}


    /* 
     MERN MEVN 
     
    M=> Mongo
    E => Express.js
    R => React.js  V => Vue  A => Angular
    N => Node.js

     */
}
