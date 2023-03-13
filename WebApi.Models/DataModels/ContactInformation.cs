using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.DataModels
{
    public class ContactInformation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string? Landline { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
    }
}
