using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Publisher>>>> GetPublishers()
        {
            var result = await _publisherService.GetPublishers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Publisher>>>> AddPublisher(Publisher publisher)
        {
            var result = await _publisherService.AddPublishers(publisher);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Publisher>>>> UpdatePublisher(Publisher publisher)
        {
            var result = await _publisherService.UpdatePublishers(publisher);
            return Ok(result);
        }

        [HttpDelete("{publisherId}")]
        public async Task<ActionResult<ServiceResponse<List<Publisher>>>> DeletePublisher(int publisherId)
        {
            var result = await _publisherService.DeletePublishers(publisherId);
            return Ok(result);
        }
    }
}
