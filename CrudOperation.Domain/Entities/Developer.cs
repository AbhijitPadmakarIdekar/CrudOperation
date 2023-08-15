﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation.Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; } = string.Empty;
        public int Followers { get; set; }
    }
}
