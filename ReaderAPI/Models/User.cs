using System;
using System.Collections.Generic;

namespace ReaderAPI.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
            Payments = new HashSet<Payment>();
        }

        public long Userid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
