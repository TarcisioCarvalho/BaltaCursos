using DependencyStore.Models;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetPromoCodeAsync(string promoCode) {}
}