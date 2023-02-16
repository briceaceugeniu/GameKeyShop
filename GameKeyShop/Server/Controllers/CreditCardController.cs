using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameKeyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<CreditCard>>> GetCreditcard()
        {
            var result = await _creditCardService.GetCreditCard();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CreditCard>>> AddOrUpdateCreditCard(CreditCard creditCard)
        {
            var result = await _creditCardService.AddOrUpdateCreditCard(creditCard);
            return Ok(result);
        }

    }
}
