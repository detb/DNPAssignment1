﻿using DNPAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}
