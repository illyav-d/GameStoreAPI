using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task AddItemAsync(T item);
        Task DeleteItemAsync(T item);
        Task<IEnumerable<T>> GetAllItemsAsync(int skip, int take);
        Task<T> GetItemByIDAsync(int id);
        Task UpdateItemAsync(T item);
    }
}
