﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.AuthModels
{
    [Table("LoginCredentials")]
    public  class RegisterDetails
    {
           
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
    }
}
