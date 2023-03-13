using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.AuthModels;
using WebApi.Repository.RepositoryActions;

namespace WebApi.BusinessLogic.AuthServices
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAuthRepository _authRepository;
        public AuthenticationServices(IAuthRepository authRepository)
        {
            _authRepository= authRepository;
        }
        /*public async Task<LoginInfo> AuthenticateUser(LoginInfo loginInfo)
        {
            var registerdUsers = await _authRepository.GetAllRegisteredUsers();
            var user = registerdUsers.FirstOrDefault(user => (loginInfo.UserName ==user.UserName) && (loginInfo.Password ==user.Password));
            return user;
        }*/
        public async Task<RegisterDetails> IsUserAlreadyExists(RegisterDetails registeredDetails)
        {
            var registerdUser = await _authRepository.CheckAvailableOrNot(registeredDetails.UserName,registeredDetails.Password);
            return registerdUser;
        }
        public async Task<RegisterDetails> AuthenticateUser(LoginInfo loginInfo)
        {
            var registerdUser = await _authRepository.CheckRegisteredOrNot(loginInfo.UserName,loginInfo.Password);
            return registerdUser;
        }
        public void AddUser(RegisterDetails loginInfo)
        {
             _authRepository.AddLoginInfo(loginInfo);
        }
    }
}
