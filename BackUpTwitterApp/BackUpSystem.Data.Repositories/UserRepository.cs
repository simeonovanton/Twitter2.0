﻿using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Date.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace BackUpSystem.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BackUpSystemDbContext dbContext)
            : base(dbContext)
        {
        }

        public User GetUserByUsername(string username)
        {
            return this.DbContext.Users
                .FirstOrDefault(u => u.UserName == username);
        }

        public IEnumerable<TwitterAccount> GetAllFavoriteTwitterAccounts(string id)
        {
            return this.DbContext.UserTwitterAccounts
                .Where(u => u.UserId == id)
                .Select(u => u.TwitterAccount)
                .ToList();
        }

        public IEnumerable<Tweet> GetAllDownloadedTweets(string id)
        {
            return this.DbContext.UserTweets
                .Where(u => u.UserId == id)
                .Select(t => t.Tweet)
                .ToList();
        }
    }
}