using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class GameProductRepository : GenericRepository<GameProductEntity>, IGameProductRepository
    {
        public GameProductRepository(GameStoreDBContext gameStoreDBContext) : base(gameStoreDBContext) { }

        public override async Task<IEnumerable<GameProductEntity>> GetAllItemsAsync(int skip, int take)
        {
            return await _gameStoreDBContext.GameProducts
                .Skip(skip)
                .Take(take)
                .Include(x => x.Genre)
                .Include(x => x.Platform)
                .ToListAsync();
        }

        public async Task<IEnumerable<GameProductEntity>> GetAllGameProductsActiveAsync(int skip, int take)
        {
            return await _gameStoreDBContext.GameProducts
                .Where(x => x.Active == true)
                .Skip(skip)
                .Take(take)
                .Include(x => x.Genre)
                .Include(x => x.Platform)
                .ToListAsync();
        }

        public async Task<IEnumerable<GameProductEntity>> GetGamesByUserInputAsync(int skip, int take, string userInput)
        {
            return await _gameStoreDBContext.GameProducts
                .Where(x => x.Active == true)
                .Where(x => x.Name.Contains(userInput))
                .Skip(skip)
                .Take(take)
                .Include(x => x.Genre)
                .Include(x => x.Platform)
                .ToListAsync();
        }

        public async Task<GameProductEntity> GetGameWithRelatedDataByIDAsync(int id)
        {
            return await _gameStoreDBContext.GameProducts
                .Include(x => x.Genre)
                .Include(x => x.Platform)
                .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<GameProductEntity>> GetGamesByGenreIDAsync(int skip, int take, int genreID)
        {
            return await _gameStoreDBContext.GameProducts
                .Where(x => x.GenreID == genreID)
                .Include(x => x.Genre)
                .Include(x => x.Platform)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<GameProductEntity>> GetGamesByPlatformIDAsync(int skip, int take, int platformID)
        {
            return await _gameStoreDBContext.GameProducts
                .Where(x => x.PlatformID == platformID)
                .Include(x => x.Genre)
                .Include(x => x.Platform)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<GameProductEntity>> GetGamesByPlatformIDAsync(int gameProductID)
        {
            return await _gameStoreDBContext.GameProducts.Where(x => x.PlatformID == gameProductID).ToListAsync();
        }
    }
}