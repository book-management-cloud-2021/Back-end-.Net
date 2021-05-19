using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagement.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Histories = new HashSet<History>();
        }

        public string ManagerUsername { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
