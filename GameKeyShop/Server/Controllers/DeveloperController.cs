using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Developer>>>> GetDevelopers()
        {
            var result = await _developerService.GetDevelopers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Developer>>>> AddDeveloper(Developer developer)
        {
            var result = await _developerService.AddDeveloper(developer);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Developer>>>> UpdateDeveloper(Developer developer)
        {
            var result = await _developerService.UpdateDeveloper(developer);
            return Ok(result);
        }
    }
}
