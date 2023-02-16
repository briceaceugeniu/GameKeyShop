namespace GameKeyShop.Server.Services.CreditCardService
{
    public interface ICreditCardService
    {
        Task<ServiceResponse<CreditCard>> GetCreditCard();
        Task<ServiceResponse<CreditCard>> AddOrUpdateCreditCard(CreditCard creditCard);
    }
}
