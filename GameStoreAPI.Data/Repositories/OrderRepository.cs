using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class OrderRepository : GenericRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(GameStoreDBContext gameStoreDBContext) : base(gameStoreDBContext)
        {
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            return await _gameStoreDBContext.Orders
                .ToArrayAsync();
        }
    }
}
