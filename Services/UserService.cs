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
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            // Mapear cada User a UserDto manualmente
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                // Mapear otras propiedades si es necesario
            }).ToList();
            return userDtos;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                // Mapear otras propiedades si es necesario
            };
            return userDto;
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                // Mapear otras propiedades si es necesario
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                // Mapear otras propiedades si es necesario
            };

            await _userRepository.UpdateUserAsync(id, user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
