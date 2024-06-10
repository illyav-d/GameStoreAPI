using GameStoreAPI.Data.Database_Context;
using GameStoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data.Repositories
{
    public class GenreRepository : GenericRepository<GenreEntity>, IGenreRepository
    {
        public GenreRepository(GameStoreDBContext gameStoreDBContext) : base(gameStoreDBContext) { }

        public async Task<IEnumerable<GenreEntity>> GetAllGenresAsync()
        {
            return await _gameStoreDBContext.Genres
                .Include(x => x.GameProducts)
                .ToArrayAsync();
        }

        public override async Task<GenreEntity> GetItemByIDAsync(int id)
        {
            return await _gameStoreDBContext.Genres.Include(x => x.GameProducts).SingleOrDefaultAsync(x => x.ID == id);
        }
    }
}
