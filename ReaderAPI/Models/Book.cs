using System;
using System.Collections.Generic;

namespace ReaderAPI.Models
{
    public partial class Book
    {
        public long Bookid { get; set; }
        public byte[]? Logo { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public long Userid { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? BookContent { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
