using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class ShoppingCartProductRepository : GenericRepository<ShoppingCartProductEntity>, IShoppingCartProductRepository
    {
        public ShoppingCartProductRepository(GameStoreDBContext gameStoreDBContext) : base(gameStoreDBContext) { }


        public async Task<IEnumerable<ShoppingCartProductEntity>> GetAllShoppingCartProductsAsync()
        {
            return await _gameStoreDBContext.ShoppingCartProducts
                .Include(x => x.User)
                .Include(x => x.GameProduct)
                .ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCartProductEntity>> GetShoppingCartByUserID(int userID)
        {
            return await _gameStoreDBContext.ShoppingCartProducts
                .Where(x => x.UserID == userID)
                .ToArrayAsync();
        }

        public async Task DeleteShoppingCartItemsByUserID(int userID)
        {
            var productsToDelete = _gameStoreDBContext.ShoppingCartProducts
                .Where(x => x.UserID == userID);
            _gameStoreDBContext.ShoppingCartProducts.RemoveRange(productsToDelete);
            _gameStoreDBContext.SaveChangesAsync();
        }
    }
}
