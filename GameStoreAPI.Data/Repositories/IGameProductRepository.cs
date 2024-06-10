using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IGameProductRepository : IGenericRepository<GameProductEntity>
    {
        Task<IEnumerable<GameProductEntity>> GetAllGameProductsActiveAsync(int skip, int take);
        Task<IEnumerable<GameProductEntity>> GetAllItemsAsync(int skip, int take);
        Task<IEnumerable<GameProductEntity>> GetGamesByGenreIDAsync(int skip, int take, int gameProductID);
        Task<IEnumerable<GameProductEntity>> GetGamesByPlatformIDAsync(int skip, int take, int platformID);
        Task<IEnumerable<GameProductEntity>> GetGamesByUserInputAsync(int skip, int take, string userInput);
        Task<GameProductEntity> GetGameWithRelatedDataByIDAsync(int id);
        Task<GameProductEntity> GetItemByIDAsync(int id);
    }
}