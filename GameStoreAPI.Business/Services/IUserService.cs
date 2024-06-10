using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Services
{
    public interface IUserService
    {
        Task<User> GetUserAndItemsInCartByIDAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync(int page, int take);
        Task UpdateUserNameAsync(int id, User user);
        Task UpdateUserActiveStateAsync(int id, User user);
        Task AddUserAsync(User user);
    }
}