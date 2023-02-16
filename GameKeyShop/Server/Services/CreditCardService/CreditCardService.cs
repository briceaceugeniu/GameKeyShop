using GameKeyShop.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GameKeyShop.Server.Services.CreditCardService
{
    public class CreditCardService : ICreditCardService
    {
        private readonly DataContext _dataContext;
        private readonly IAuthService _authService;

        public CreditCardService(DataContext dataContext, IAuthService authService)
        {
            _dataContext = dataContext;
            _authService = authService;
        }

        public async Task<ServiceResponse<CreditCard>> GetCreditCard()
        {
            try
            {
                var userId = _authService.GetUserId();
                var creditCard = await _dataContext.CreditCards
                    .FirstOrDefaultAsync(a => a.UserId == userId);
                return new ServiceResponse<CreditCard> { Data = creditCard };
            }
            catch (Exception e)
            {
                return new ServiceResponse<CreditCard>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not get credit card info. Error: {e.Message}"                 };
            }
        }

        public async Task<ServiceResponse<CreditCard>> AddOrUpdateCreditCard(CreditCard creditCard)
        {
            var response = new ServiceResponse<CreditCard>();

            try
            {
                var dbCreditCard = (await GetCreditCard()).Data;
                if (dbCreditCard == null)
                {
                    creditCard.UserId = _authService.GetUserId();
                    _dataContext.CreditCards.Add(creditCard);
                    response.Data = creditCard;
                }
                else
                {
                    dbCreditCard.Owner = creditCard.Owner;
                    dbCreditCard.CVV = creditCard.CVV;
                    dbCreditCard.Number = creditCard.Number;
                    dbCreditCard.ExpirationDate = creditCard.ExpirationDate;

                    response.Data = dbCreditCard;
                }

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Could not add/update credit card. Error: {e.Message}";
            }

            return response;
        }
    }
}
