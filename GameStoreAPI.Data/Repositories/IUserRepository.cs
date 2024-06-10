using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity> GetUserAndItemsInCartByIDAsync(int id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync(int skip, int take);
    }
}