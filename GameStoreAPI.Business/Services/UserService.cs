using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.Data.Repositories;
namespace GameStoreAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserAndItemsInCartByIDAsync(int id)
        {
            UserEntity userEntity = await _userRepository.GetUserAndItemsInCartByIDAsync(id);

            if (userEntity == null)
            {
                return null;
            }

            User user = _mapper.Map<User>(userEntity);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(int page, int take)
        {
            int skip = (page - 1) * take;

            List<User> users = new List<User>();
            IEnumerable<UserEntity> userEntities = await _userRepository.GetAllUsersAsync(skip, take);

            // Map the UserEntities to User models
            users = _mapper.Map<List<User>>(userEntities);
            return users;
        }

        public async Task UpdateUserNameAsync(int id, User user)
        {
            UserEntity objectDB = await _userRepository.GetItemByIDAsync(id);

            UserEntity updatedObject = _mapper.Map<UserEntity>(user);

            objectDB.Name = updatedObject.Name;
            objectDB.Updated = DateTime.Now;
            await _userRepository.UpdateItemAsync(objectDB);
        }

        public async Task UpdateUserActiveStateAsync(int id, User user)
        {
            UserEntity objectDB = await _userRepository.GetItemByIDAsync(id);

            UserEntity updatedObject = _mapper.Map<UserEntity>(user);

            objectDB.Active = updatedObject.Active;
            objectDB.Updated = DateTime.Now;
            await _userRepository.UpdateItemAsync(objectDB);
        }

        public async Task AddUserAsync(User user)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            userEntity.Active = true;
            userEntity.Created = DateTime.Now;
            userEntity.Updated = DateTime.Now;
            await _userRepository.AddItemAsync(userEntity);
        }
    }
}
