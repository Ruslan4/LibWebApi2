﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLibrary.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}