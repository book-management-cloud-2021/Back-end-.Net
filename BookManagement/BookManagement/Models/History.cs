using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagement.Models
{
    public partial class History
    {
        public Guid HistoryId { get; set; }
        public Guid? BookId { get; set; }
        public int? Amount { get; set; }
        public Guid? CustomerId { get; set; }
        public string ManagerUsername { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Manager ManagerUsernameNavigation { get; set; }
    }
}
