using System;
using System.Collections.Generic;

namespace AuthorAPI.Models
{
    public partial class Payment
    {
        public long Paymentid { get; set; }
        public string? Email { get; set; }
        public long Userid { get; set; }
        public long Bookid { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
