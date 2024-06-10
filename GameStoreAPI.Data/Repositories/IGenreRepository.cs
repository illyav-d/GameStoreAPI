using GameStoreAPI.Data.Entities;

namespace GameStoreAPI.Data.Repositories
{
    public interface IGenreRepository : IGenericRepository<GenreEntity>
    {
        Task<IEnumerable<GenreEntity>> GetAllGenresAsync();
        Task<GenreEntity> GetItemByIDAsync(int id);
    }
}