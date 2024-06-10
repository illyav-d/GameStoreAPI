using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddOrderAsync(int customerID);
        Task CheckoutAsync(int customerID);
        string ConvertGameTitlesArrayToString(string[] stringArray);
    }
}