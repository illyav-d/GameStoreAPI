using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Services
{
    public interface IGenreService
    {
        Task AddGenreAsync(Genre genre);
        Task DeleteGenreByIDAsync(int id);
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIDAsync(int id);
        Task UpdateGenreAsync(int id, Genre genre);
    }
}