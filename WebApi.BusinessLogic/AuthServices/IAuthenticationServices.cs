using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.AuthModels;

namespace WebApi.BusinessLogic.AuthServices
{
    public interface IAuthenticationServices
    {
        //public  Task<LoginInfo> AuthenticateUser(LoginInfo loginInfo);
        public  Task<RegisterDetails> IsUserAlreadyExists(RegisterDetails registeredDetails);
        public  Task<RegisterDetails> AuthenticateUser(LoginInfo loginInfo);
        public void AddUser(RegisterDetails loginInfo);
    }
}
