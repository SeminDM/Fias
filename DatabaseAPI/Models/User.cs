﻿using System;
using Microsoft.AspNetCore.Identity;

namespace DatabaseAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
