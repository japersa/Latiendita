using Latiendita.Dtos;
using Latiendita.Models;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
         return await _userRepository.GetUserByIdAsync(id);   
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                UserName = userDto.UserName,
                Password = userDto.Password
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                UserName = userDto.UserName,
                Password = userDto.Password
            };

            await _userRepository.UpdateUserAsync(id, user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
