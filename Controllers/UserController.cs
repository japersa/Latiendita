<<<<<<< HEAD
﻿using Latiendita.Dtos;
using Latiendita.Services;
using System.Threading.Tasks;
=======
using Latiendita.Models;
>>>>>>> origin/main
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
<<<<<<< HEAD
    [Route("api/users")]
=======
    [Route("/api/users")]
>>>>>>> origin/main
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
=======
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUser([FromQuery] string query)
        {
            var users = await _userService.SearchUsers(query);
>>>>>>> origin/main
            return Ok(users);
        }

        [HttpGet("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
=======
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"No user found with ID {id}");
            }
>>>>>>> origin/main
            return Ok(user);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Create(UserDto userDto)
        {
            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
=======
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"No user found with ID {id}");
            }
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
>>>>>>> origin/main
