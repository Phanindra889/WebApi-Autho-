using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.AuthModels;

namespace WebApi.BusinessLogic.AuthServices
{
    public  interface ITokenHandler
    {
        public List<Claim> Claims { get; set; }
        public string CreateToken(RegisterDetailsDTO loginInfo);
    }
}
