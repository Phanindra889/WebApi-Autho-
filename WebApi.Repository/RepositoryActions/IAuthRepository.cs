using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.AuthModels;

namespace WebApi.Repository.RepositoryActions
{
    public interface IAuthRepository
    {
        public  Task<RegisterDetails> CheckAvailableOrNot(string userName,string password);
        public  Task<RegisterDetails> CheckRegisteredOrNot(string userName, string password);
        public void AddLoginInfo(RegisterDetails loginInfo);
    }
}
