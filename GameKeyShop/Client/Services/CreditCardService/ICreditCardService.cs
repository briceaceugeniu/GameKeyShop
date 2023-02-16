namespace GameKeyShop.Client.Services.CreditCardService
{
    public interface ICreditCardService
    {
        Task<CreditCard> GetCreditCard();
        Task<CreditCard> AddOrUpdateCreditCard(CreditCard creditCard);
    }
}
