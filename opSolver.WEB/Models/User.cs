﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opSolver.WEB.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}