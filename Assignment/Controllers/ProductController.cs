using Assignment.DTO;
using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Assignment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Product> productList = context.Products.ToList();
            return Ok(productList);
        }

        [HttpPost]
        public IActionResult Add([FromForm] ProductDTO proDTO)
        {
            using var datastream = new MemoryStream();
            proDTO.Image.CopyTo(datastream);
            var product = new Product()
            {
                ProductName = proDTO.ProductName,
                Cateogey = proDTO.Cateogey,
                Image = datastream.ToArray(),
                Price = proDTO.Price,
                MinimunQuentity = proDTO.MinimunQuentity,
                DiscountRate = proDTO.DiscountRate,
            };
            context.Add(product);
            context.SaveChanges();
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] ProductDTO proDto)
        {

            var product = context.Products.Find(id);
            if (product == null)
                return NotFound($" No product was found with ID {id}");

            using var datastream = new MemoryStream();
            proDto.Image.CopyTo(datastream);
            product.ProductName = proDto.ProductName;
            product.Cateogey = proDto.Cateogey;
            product.Image = datastream.ToArray();
            product.Price = proDto.Price;

            context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
                return NotFound($"Product not found{id}");
            context.Remove(product);
            context.SaveChanges();
            return Ok(product);
        }
    }
}
    

