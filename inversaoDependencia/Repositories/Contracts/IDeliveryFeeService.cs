public interface IDeliveryFeeService
{
    Task<decimal> GetDeliveryFeeAsync(string zipCode);
}