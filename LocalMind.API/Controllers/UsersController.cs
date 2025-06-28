﻿using LocalMind.API.DTOs;
using LocalMind.API.Models.Users;
using LocalMind.API.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync([FromBody] UserDto userDto)
        {
            UserDto newUser =
                await this.userService.AddUserAsync(userDto);

            return StatusCode(201, userDto);
        }

        [HttpGet]
        public ActionResult<IQueryable<UserDto>> GetAllUsers()
        {
            IQueryable<UserDto> users =
                this.userService.RetrieveAllUsers();

            return Ok(users);
        }
    }
}
