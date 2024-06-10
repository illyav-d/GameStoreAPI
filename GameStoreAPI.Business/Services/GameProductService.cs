using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.Data.Repositories;

namespace GameStoreAPI.Business.Services
{
    public class GameProductService : IGameProductService
    {
        private readonly IGameProductRepository _gameProductRepository;
        private IMapper _mapper;

        public GameProductService(IMapper mapper, IGameProductRepository gameProductRepository)
        {
            _mapper = mapper;
            _gameProductRepository = gameProductRepository;
        }

        public async Task<GameProduct> GetGameProductByIDAsync(int id)
        {

            GameProductEntity gameProductEntity = await _gameProductRepository.GetGameWithRelatedDataByIDAsync(id);

            if (gameProductEntity == null)
            {
                return null;
            }

            GameProduct gameProduct = _mapper.Map<GameProduct>(gameProductEntity);

            return gameProduct;
        }

        public async Task<IEnumerable<GameProduct>> GetAllGameProductsAsync(int page, int take)
        {
            int skip = (page - 1) * take;

            List<GameProduct> games = new List<GameProduct>();
            IEnumerable<GameProductEntity> gameProductEntities = await _gameProductRepository.GetAllItemsAsync(skip, take);

            // Map the GameProductEntities to GameProduct models
            games = _mapper.Map<List<GameProduct>>(gameProductEntities);
            return games;
        }

        public async Task<IEnumerable<GameProduct>> GetAllGameProductsActiveAsync(int page, int take)
        {
            int skip = (page - 1) * take;

            List<GameProduct> games = new List<GameProduct>();
            IEnumerable<GameProductEntity> gameProductEntities = await _gameProductRepository.GetAllGameProductsActiveAsync(skip, take);

            // Map the GameProductEntities to GameProduct models
            games = _mapper.Map<List<GameProduct>>(gameProductEntities);
            return games;
        }

        public async Task<IEnumerable<GameProduct>> GetGamesByNameAsync(int page, int take, string userInput)
        {
            int skip = (page - 1) * take;

            List<GameProduct> games = new List<GameProduct>();
            IEnumerable<GameProductEntity> gameProductEntities = await _gameProductRepository.GetGamesByUserInputAsync(skip, take, userInput);

            // Map the GameProductEntities to GameProduct models
            games = _mapper.Map<List<GameProduct>>(gameProductEntities);
            return games;
        }

        public async Task<IEnumerable<GameProduct>> GetGamesByGenreIDAsync(int page, int take, int genreID)
        {
            int skip = (page - 1) * take;

            List<GameProduct> games = new List<GameProduct>();
            IEnumerable<GameProductEntity> gameProductEntities = await _gameProductRepository.GetGamesByGenreIDAsync(skip, take, genreID);

            // Map the GameProductEntities to GameProduct models
            games = _mapper.Map<List<GameProduct>>(gameProductEntities);
            return games;
        }

        public async Task<IEnumerable<GameProduct>> GetGamesByPlatformIDAsync(int page, int take, int platformID)
        {
            int skip = (page - 1) * take;

            List<GameProduct> games = new List<GameProduct>();
            IEnumerable<GameProductEntity> gameProductEntities = await _gameProductRepository.GetGamesByPlatformIDAsync(skip, take, platformID);

            // Map the GameProductEntities to GameProduct models
            games = _mapper.Map<List<GameProduct>>(gameProductEntities);
            return games;
        }

        public async Task AddGameProductAsync(GameProduct game)
        {
            GameProductEntity gameProductEntity = _mapper.Map<GameProductEntity>(game);
            gameProductEntity.Created = DateTime.Now;
            gameProductEntity.Updated = DateTime.Now;
            await _gameProductRepository.AddItemAsync(gameProductEntity);
        }

        public async Task UpdateGameProductPriceAsync(int id, GameProduct gameProduct)
        {
            GameProductEntity objectDB = await _gameProductRepository.GetItemByIDAsync(id);
            GameProductEntity changedPriceObject = _mapper.Map<GameProductEntity>(gameProduct);
            objectDB.PriceInEuro = changedPriceObject.PriceInEuro;
            objectDB.Updated = DateTime.Now;
            await _gameProductRepository.UpdateItemAsync(objectDB);
        }

        public async Task UpdateGameProductStockAsync(int id, GameProduct gameProduct)
        {
            GameProductEntity objectDB = await _gameProductRepository.GetItemByIDAsync(id);
            GameProductEntity changedPriceObject = _mapper.Map<GameProductEntity>(gameProduct);
            objectDB.Stock = changedPriceObject.Stock;
            objectDB.Updated = DateTime.Now;
            await _gameProductRepository.UpdateItemAsync(objectDB);
        }

        public async Task UpdateGameProductActiveStateAsync(int id, GameProduct gameProduct)
        {
            GameProductEntity objectDB = await _gameProductRepository.GetItemByIDAsync(id);
            GameProductEntity changedStateObject = _mapper.Map<GameProductEntity>(gameProduct);
            objectDB.Active = changedStateObject.Active;
            objectDB.Updated = DateTime.Now;
            await _gameProductRepository.UpdateItemAsync(objectDB);
        }

        public async Task UpdateGameProductAsync(int id, GameProduct gameProduct)
        {
            GameProductEntity objectDB = await _gameProductRepository.GetItemByIDAsync(id);

            GameProductEntity updatedObject = _mapper.Map<GameProductEntity>(gameProduct);

            objectDB = await MapDataManually(objectDB, updatedObject);

            await _gameProductRepository.UpdateItemAsync(objectDB);
        }

        private async Task<GameProductEntity> MapDataManually(GameProductEntity objectDB, GameProductEntity updatedObject)
        {
            objectDB.Name = updatedObject.Name;
            objectDB.Description = updatedObject.Description;
            objectDB.Developer = updatedObject.Developer;
            objectDB.Genre = updatedObject.Genre;
            objectDB.GenreID = updatedObject.GenreID;
            objectDB.ImageURL = updatedObject.ImageURL;
            objectDB.MinimumAge = updatedObject.MinimumAge;
            objectDB.Platform = updatedObject.Platform;
            objectDB.PlatformID = updatedObject.PlatformID;
            objectDB.PriceInEuro = updatedObject.PriceInEuro;
            objectDB.Publisher = updatedObject.Publisher;
            objectDB.ReleaseDate = updatedObject.ReleaseDate;
            objectDB.Stock = updatedObject.Stock;
            objectDB.Active = updatedObject.Active;
            objectDB.Updated = DateTime.Now;

            return objectDB;
        }
    }
}
