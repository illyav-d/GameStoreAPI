using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Services
{
    public interface IPlatformService
    {
        Task AddPlatformAsync(Platform platform);
        Task DeletePlatformByIDAsync(int id);
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform> GetPlatformByIDAsync(int id);
        Task UpdatePlatformAsync(int id, Platform genre);
    }
}