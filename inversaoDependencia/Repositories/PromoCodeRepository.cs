using Dapper;
using DependencyStore.Models;
using Microsoft.Data.SqlClient;

public class PromoCodeRepository : IPromoCodeRepository
{
    private readonly SqlConnection _connection;
    public PromoCodeRepository(SqlConnection connection) =>
    _connection = connection;

    public async Task<PromoCode?> GetPromoCodeAsync(string promoCode) 
    {
         const string query = "SELECT * FROM PROMO_CODES WHERE CODE=@code";
         var promo = await _connection.QueryFirstAsync<PromoCode>(query,
         new { code = promoCode });
         if (promo.ExpireDate > DateTime.Now)
                discount = promo.Value;
    }
}