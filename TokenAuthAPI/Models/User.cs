using System.ComponentModel.DataAnnotations;

namespace TokenAuthAPI.Models
{
    public partial class User
    {
        [Key]
        public long Userid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
    }
}
