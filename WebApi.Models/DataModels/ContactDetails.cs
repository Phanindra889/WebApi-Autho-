﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.DataModels
{
    [Table("ASPContactInformation")]
    public class ContactDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string? Landline { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
    }
}
