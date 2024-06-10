using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.Data.Repositories;

namespace GameStoreAPI.Business.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Genre> GetGenreByIDAsync(int id)
        {
            GenreEntity genreEntity = await _genreRepository.GetItemByIDAsync(id);

            if (genreEntity == null)
            {
                return null;
            }

            Genre genre = _mapper.Map<Genre>(genreEntity);

            return genre;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            IEnumerable<GenreEntity> genreEntity = await _genreRepository.GetAllGenresAsync();
            IEnumerable<Genre> allGenres = _mapper.Map<IEnumerable<Genre>>(genreEntity);
            return allGenres;
        }

        public async Task AddGenreAsync(Genre genre)
        {
            GenreEntity genreEntity = _mapper.Map<GenreEntity>(genre);
            genreEntity.Created = DateTime.Now;
            genreEntity.Updated = DateTime.Now;
            await _genreRepository.AddItemAsync(genreEntity);
        }

        public async Task DeleteGenreByIDAsync(int id)
        {
            GenreEntity genreEntity = new GenreEntity { ID = id };
            await _genreRepository.DeleteItemAsync(genreEntity);
        }

        public async Task UpdateGenreAsync(int id, Genre genre)
        {
            GenreEntity objectDB = await _genreRepository.GetItemByIDAsync(id);

            GenreEntity updatedObject = _mapper.Map<GenreEntity>(genre);

            objectDB.Name = updatedObject.Name;
            objectDB.Updated = DateTime.Now;
            await _genreRepository.UpdateItemAsync(objectDB);
        }
    }
}
