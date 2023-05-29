﻿using System.ComponentModel.DataAnnotations;
namespace Backend.Request
{
    public class AccountGetDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Balance { get; set; }
    }
}
