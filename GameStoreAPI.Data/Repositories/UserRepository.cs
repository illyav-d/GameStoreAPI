using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(GameStoreDBContext gameStoreDBContext) : base(gameStoreDBContext) { }

        public async Task<UserEntity> GetUserAndItemsInCartByIDAsync(int id)
        {
            return await _gameStoreDBContext.Users
                .Include(x => x.ShoppingCartProducts)
                .ThenInclude(x => x.GameProduct)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync(int skip, int take)
        {
            return await _gameStoreDBContext.Users
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
