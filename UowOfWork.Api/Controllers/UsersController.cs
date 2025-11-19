using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Contracts.User;

namespace UowOfWork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string name, string lastName)
        {
            await _service.CreateUserAsync(name, lastName);
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetUsersAsync();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
