using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Services
{
    public interface IShoppingCartProductService
    {
        Task<IEnumerable<ShoppingCartProduct>> GetAllShoppingCartProductsAsync();
        Task AddShoppingCartProductAsync(ShoppingCartProduct cartItem);
        Task UpdateProductAmountAsync(int id, ShoppingCartProduct shoppingCartProduct);
        Task DeleteShoppingCartProductByIDAsync(int id);
        Task DeleteUserShoppingCartProductsByUserIDAsync(int userID);
    }
}