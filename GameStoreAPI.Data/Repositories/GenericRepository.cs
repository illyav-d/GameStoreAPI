using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class, IEntity
    {
        protected GameStoreDBContext _gameStoreDBContext;
        private DbSet<T> table;

        public GenericRepository(GameStoreDBContext gameStoreDBContext )
        {
            this._gameStoreDBContext = gameStoreDBContext;
            this.table = gameStoreDBContext.Set<T>();
        }

        public async Task AddItemAsync(T item)
        {
            await table.AddAsync(item);
            await _gameStoreDBContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllItemsAsync(int skip, int take)
        {
            return await table
                .Skip(skip)
                .Take(take)
                .ToArrayAsync();
        }

        public virtual async Task<T> GetItemByIDAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task UpdateItemAsync(T item)
        {
            table.Update(item);
            await _gameStoreDBContext.SaveChangesAsync();
        }
        
        public async Task DeleteItemAsync(T item)
        {
            table.Remove(item);
            await _gameStoreDBContext.SaveChangesAsync();
        }
    }
}
