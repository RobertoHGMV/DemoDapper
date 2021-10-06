using System.Threading.Tasks;
using DemoDapper.Api.Domain.Models;
using DemoDapper.Api.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var result = await _repository.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("result")]
        public async Task<IActionResult> GetItemResult()
        {
            var result = await _repository.GetItemResultAsync();
            return Ok(result);            
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Item item)
        {
            var result = await _repository.AddAsync(item);
            return Created("", result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Item item)
        {
            var result = await _repository.UpdateAsync(id, item);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}