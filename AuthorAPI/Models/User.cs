using System;
using System.Collections.Generic;

namespace AuthorAPI.Models
{
    public partial class User
    {        

        public long Userid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }

    }
}
