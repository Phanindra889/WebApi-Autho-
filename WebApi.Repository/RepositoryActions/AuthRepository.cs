using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.AuthModels;
using WebApi.Repository.Context;

namespace WebApi.Repository.RepositoryActions
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDapperContext _context;
        public AuthRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<RegisterDetails> CheckAvailableOrNot(string userName, string password)
        {
            var registeredUsers = await _context.Connection.GetAllAsync<RegisterDetails>();
            var user = registeredUsers.SingleOrDefault(user => (userName == user.UserName) && (password == user.Password));
            return user;
        }
        public async Task<RegisterDetails> CheckRegisteredOrNot(string userName, string password)
        {
            var registeredUsers = await _context.Connection.GetAllAsync<RegisterDetails>();
            var user = registeredUsers.SingleOrDefault(user => (userName == user.UserName) && (password == user.Password));
            return user;
        }
        public async void AddLoginInfo(RegisterDetails loginInfo)
        {
            await _context.Connection.InsertAsync(loginInfo);
        }
    }
}
