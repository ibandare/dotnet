﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Model
{
    internal class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [DefaultValue(0)]
        public int Wins { get; set; }

        [DefaultValue(0)]
        public int Losses { get; set; }
    }
}
