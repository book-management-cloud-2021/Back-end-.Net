using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagement.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Histories = new HashSet<History>();
        }

        public Guid CustomerId { get; set; }
        public string Fullname { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? InsertedAt { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
