using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Services
{
    public interface IGameProductService
    {
        Task AddGameProductAsync(GameProduct game);
        Task<IEnumerable<GameProduct>> GetAllGameProductsActiveAsync(int page, int take);
        Task<IEnumerable<GameProduct>> GetAllGameProductsAsync(int page, int take);
        Task<GameProduct> GetGameProductByIDAsync(int id);
        Task<IEnumerable<GameProduct>> GetGamesByNameAsync(int page, int take, string userInput);
        Task<IEnumerable<GameProduct>> GetGamesByGenreIDAsync(int page, int take, int genreID);
        Task<IEnumerable<GameProduct>> GetGamesByPlatformIDAsync(int page, int take, int platformID);
        Task UpdateGameProductActiveStateAsync(int id, GameProduct gameProduct);
        Task UpdateGameProductAsync(int id, GameProduct gameProduct);
        Task UpdateGameProductPriceAsync(int id, GameProduct gameProduct);
        Task UpdateGameProductStockAsync(int id, GameProduct gameProduct);
    }
}