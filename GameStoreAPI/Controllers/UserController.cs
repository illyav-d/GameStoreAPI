using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Business.Services;
using GameStoreAPI.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("GetUserByID")]
        public async Task<ActionResult<DetailedUserDTO>> GetUserByIDAsync(int id)
        {
            User user = await _userService.GetUserAndItemsInCartByIDAsync(id);
            DetailedUserDTO userDTO = _mapper.Map<DetailedUserDTO>(user);

            if (userDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<SimplifiedUserDTO>> GetAllUsersAsync(int page = 1, int items = 10)
        {
            IEnumerable<User> usersModel = await _userService.GetAllUsersAsync(page, items);
            IEnumerable<SimplifiedUserDTO> usersDTO = _mapper.Map<IEnumerable<SimplifiedUserDTO>>(usersModel);

            if (usersDTO == null || usersDTO.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(usersDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddGenreAsync(AddUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(userDTO);
                await _userService.AddUserAsync(user);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateUserName")]
        public async Task<ActionResult<UpdateUserNameDTO>> UpdateUserNameAsync(int id, UpdateUserNameDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(userDTO);
                await _userService.UpdateUserNameAsync(id, user);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateUserActiveState")]
        public async Task<ActionResult<UpdateUserNameDTO>> UpdateUserActiveStateAsync(int id, UpdateUserActiveStateDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(userDTO);
                await _userService.UpdateUserActiveStateAsync(id, user);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
