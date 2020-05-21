﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeinesCamp.Model;

namespace FeinesCamp.Services
{
    public interface IDataService
    {
        Task<User> GetUserAsync(string jwtId);


    }
}