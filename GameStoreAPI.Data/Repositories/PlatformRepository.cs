using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class PlatformRepository : GenericRepository<PlatformEntity>, IPlatformRepository
    {
        public PlatformRepository(GameStoreDBContext gameStoreDBContext) : base(gameStoreDBContext) { }

        public async Task<IEnumerable<PlatformEntity>> GetAllPlatformsAsync()
        {
            return await _gameStoreDBContext.Platforms
                .Include(x => x.GameProducts)
                .ToArrayAsync();
        }

        public override async Task<PlatformEntity> GetItemByIDAsync(int id)
        {
            return await _gameStoreDBContext.Platforms.Include(x => x.GameProducts).SingleOrDefaultAsync(x => x.ID == id);
        }
    }
}
