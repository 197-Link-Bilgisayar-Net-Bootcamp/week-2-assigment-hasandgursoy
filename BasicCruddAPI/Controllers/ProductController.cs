using Application.DTOs.Product;
using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicCruddAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {

            return Ok(await _productReadRepository.GetByIdAsync(id, false));

        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody]Create_Product_Dto model)
        {

            await _productWriteRepository.AddAsync(new ()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });


            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Updated_Product_Dto model)
        {

            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            await _productWriteRepository.SaveAsync();
            return Ok();



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();


        }

    }

}