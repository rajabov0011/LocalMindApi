﻿using LocalMind.API.DataContext;
using LocalMind.API.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LocalMind.API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async ValueTask<User> InsertUserAsync(User user)
        {
            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        public IQueryable<User> SelectAllUsers() =>
            this.context.Users.Include(user => user.UserAdditionalDetail);
    }
}
