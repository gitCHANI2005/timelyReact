using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dtos;
using Service.Interfaces;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //i change
        //2 change
        private readonly IService<ProductDto> _productService;
        public static string _directory = Environment.CurrentDirectory + "/images/";
        public ProductController(IService<ProductDto> productService)
        {
            _productService = productService;
        }
    
        // GET: api/<ProductController>
        [HttpGet]
        public List<ProductDto> Get()
        {
            return _productService.getAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return _productService.getById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ProductDto Post([FromForm] ProductDto value)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory , "Images/", value.File.FileName); //l:/...
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                value.File.CopyTo(fs);
               // fs.Close();
            }
            //
         return   _productService.addItem(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
