﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Color { get; set; }
    }
}
