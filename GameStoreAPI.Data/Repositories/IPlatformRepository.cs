using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IPlatformRepository : IGenericRepository<PlatformEntity>
    {
        Task<PlatformEntity> GetItemByIDAsync(int id);
        Task<IEnumerable<PlatformEntity>> GetAllPlatformsAsync();
    }
}