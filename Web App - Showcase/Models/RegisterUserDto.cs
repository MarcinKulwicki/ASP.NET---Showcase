﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Web_App___Showcase.Models
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Roleid { get; set; } = 1;
    }
}
