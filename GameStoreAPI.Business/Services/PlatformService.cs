using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.Data.Repositories;

namespace GameStoreAPI.Business.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private IMapper _mapper;

        public PlatformService(IMapper mapper, IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<Platform> GetPlatformByIDAsync(int id)
        {

            PlatformEntity platformEntity = await _platformRepository.GetItemByIDAsync(id);

            if (platformEntity == null)
            {
                return null;
            }

            Platform platform = _mapper.Map<Platform>(platformEntity);

            return platform;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            IEnumerable<PlatformEntity> platformEntity = await _platformRepository.GetAllPlatformsAsync();
            IEnumerable<Platform> allPlatforms = _mapper.Map<IEnumerable<Platform>>(platformEntity);
            return allPlatforms;
        }

        public async Task AddPlatformAsync(Platform platform)
        {
            PlatformEntity platformEntity = _mapper.Map<PlatformEntity>(platform);
            platformEntity.Created = DateTime.Now;
            platformEntity.Updated = DateTime.Now;
            await _platformRepository.AddItemAsync(platformEntity);
        }

        public async Task DeletePlatformByIDAsync(int id)
        {
            PlatformEntity platformEntity = new PlatformEntity { ID = id };
            await _platformRepository.DeleteItemAsync(platformEntity);
        }

        public async Task UpdatePlatformAsync(int id, Platform genre)
        {
            PlatformEntity objectDB = await _platformRepository.GetItemByIDAsync(id);

            PlatformEntity updatedObject = _mapper.Map<PlatformEntity>(genre);

            objectDB.Name = updatedObject.Name;
            objectDB.Updated = DateTime.Now;
            await _platformRepository.UpdateItemAsync(objectDB);
        }
    }
}
