using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<OrderEntity>
    {
        Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
    }
}