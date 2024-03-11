using ApiProject.Infrastructure.Repository.MajorRepository;
using ApiProject.Infrastructure.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorRepository _majorRepository;
        public MajorController(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _majorRepository.GetAll());
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _majorRepository.GetById(id));
        }
    }
}
