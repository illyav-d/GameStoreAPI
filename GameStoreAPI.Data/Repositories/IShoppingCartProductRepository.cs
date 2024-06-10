using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IShoppingCartProductRepository : IGenericRepository<ShoppingCartProductEntity>
    {
        Task<IEnumerable<ShoppingCartProductEntity>> GetAllShoppingCartProductsAsync();
        Task DeleteShoppingCartItemsByUserID(int userID);
        Task<IEnumerable<ShoppingCartProductEntity>> GetShoppingCartByUserID(int userID);
    }
}