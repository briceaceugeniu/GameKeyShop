using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PlatformTypeController : ControllerBase
    {
        private readonly IPlatformTypeService _platformTypeService;

        public PlatformTypeController(IPlatformTypeService platformTypeService)
        {
            _platformTypeService = platformTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PlatformType>>>> GetPlatformTypes()
        {
            var response = await _platformTypeService.GetPlatformTypes();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PlatformType>>>> AddPlatformType(PlatformType platformType)
        {
            var response = await _platformTypeService.AddPlatformType(platformType);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PlatformType>>>> UpdatePlatformType(
            PlatformType platformType)
        {
            var response = await _platformTypeService.UpdatePlatformType(platformType);
            return Ok(response);
        }
    }
}
