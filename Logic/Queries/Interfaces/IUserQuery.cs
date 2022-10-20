﻿using Logic.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface IUserQuery
    {
        public List<GetUserResponse> GetAll();
    }
}
